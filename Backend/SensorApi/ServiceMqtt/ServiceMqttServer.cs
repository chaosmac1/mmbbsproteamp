using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Extensions.Hosting;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet.Server;
using SensorLib.Database;
using SensorLib.Manager;
using SensorLib.Utils;

namespace ServiceMqtt; 

public class ServiceMqttServer: IHostedService {
    private MqttServer? mqtt;
    private const string TopicTemp = "temp";
    private const string ServerUsername = "Server";
    private static string ServerPassword = Guid.NewGuid().ToString();
    private const int Port = 6666;
    private async Task ValidatingConnection(ValidatingConnectionEventArgs args) {
        await using var db = await DbBuilder.BuildNpgsqlAsync();
        if (args.UserName == ServerUsername) {
            if (ServerPassword != args.Password) {
                args.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                return;
            }
            args.ReasonCode = MqttConnectReasonCode.Success;
            return;
        }
        
        var authData = await MqttClientAuthManager.GetByNameAsync(db, args.UserName ?? "");
        if (authData is null) {
            await args.ChannelAdapter.DisconnectAsync(default);
            return;
        }

        if (Password.Valid(args.Password, authData.Password) == false) {
            args.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
            return;
        }

        args.ReasonCode = MqttConnectReasonCode.Success;
    }

    private async Task ClientMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs args) {
        var json = System.Text.Encoding.UTF8.GetString(args.ApplicationMessage.PayloadSegment);
        
        return Task.CompletedTask;
    }
    
    private async Task StartServerAsync(CancellationToken cancellationToken) {
        var mqttFactory = new MqttFactory();
        
        var mqttServerOptions = new MqttServerOptionsBuilder()
            .WithDefaultEndpoint()
            .WithDefaultEndpointBoundIPAddress(IPAddress.Any)
            .WithDefaultEndpointPort(Port)
            .Build();
        
        mqtt = mqttFactory.CreateMqttServer(mqttServerOptions);
        mqtt.ValidatingConnectionAsync += this.ValidatingConnection;
        mqtt.InterceptingPublishAsync += args => {
            if (args.ApplicationMessage.Topic != TopicTemp) {
                args.Response.ReasonCode = MqttPubAckReasonCode.TopicNameInvalid;
            }

            return Task.CompletedTask;
        };
        await mqtt.StartAsync();
    }

    private async Task StartClientAsync(CancellationToken cancellationToken) {
        var mqttFactory = new MqttFactory();

        using var mqttClient = mqttFactory.CreateMqttClient();
        var mqttClientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer("127.0.0.1", Port)
            .Build();

        mqttClient.ApplicationMessageReceivedAsync += ClientMessageReceivedAsync;

        await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

        var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(
                f => { f.WithTopic(TopicTemp); })
            .Build();

        await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
    }
    
    public async Task StartAsync(CancellationToken cancellationToken) {
        await StartServerAsync(cancellationToken);
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        await StartClientAsync(cancellationToken);
    }
    
    

    public async Task StopAsync(CancellationToken cancellationToken) {
        await mqtt.StopAsync();
    }
}