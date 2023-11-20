using LamLibAllOver;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port;

namespace Sensor.Service.AttachmentService;

public struct AttachmentService< 
    Input, 
    Dto,
    Handler,
    HandlerOutput> 
    where Input: IInput
    where Dto: IDto, IDtoFrom<Dto, Input>
    where HandlerOutput: IHandlerOutput
    where Handler: IHandler<Dto, HandlerOutput>, new() {
    
    public async Task<StatusOutput<HandlerOutput>> RunAsync(
        Input request, 
        IApiProxy apiProxy,
        bool needCookie,
        CancellationToken token = default) {
        
        try {
            var api = this;
            var task = Task
                       .Factory
                       .StartNew(() => api.RunFullAsync(
                           request, 
                           apiProxy, 
                           needCookie), 
                           TaskCreationOptions.PreferFairness)
                       .Unwrap();
            
            await task.WaitAsync(token);
            if (task.IsCompleted == false)
                return StatusOutput<HandlerOutput>.AsInternelServerError(TraceMsg.WithMessage("IsNotCompleted"));

            var result = task.Result;
            return result;
        }
        catch (Exception e) {
            throw;
        }
    }

    private async Task<StatusOutput<HandlerOutput>> RunFullAsync(
        Input request, 
        IApiProxy apiProxy,
        bool needCookie) {
        
        Dto dto = default;
        try {
            
            dto = Dto.From(request);
            if (!ValidationParser.Validating(dto)) {
                return StatusOutput<HandlerOutput>.AsBadRequest();
            }
        }
        catch (Exception) {
            return StatusOutput<HandlerOutput>.AsBadRequest();
        }

        var handler = new Handler();
        
        var dbWrapper = await Sensor.Repository.Database.Builder.BuildDbWrapper();
        
        try {
            Option<Sensor.Domain.ValueObject.UserIdAndToken> cookieAndUserId = default;
            if (needCookie) {
                var cookieOp = apiProxy.GetCookie();
                if (cookieOp.IsNotSet()) {
                    await dbWrapper.RollbackAsync();    
                    return StatusOutput<HandlerOutput>.AsForbidden();
                }
                
                var userCookieOp = await Sensor.Core.Manager.ManagerUserCookie.GetByIdAsync(
                    dbWrapper.Db, 
                    new () { Value = cookieOp.Unwrap().Value }
                );
                
                if (userCookieOp.IsNotSet()) {
                    await dbWrapper.RollbackAsync();    
                    return StatusOutput<HandlerOutput>.AsForbidden();
                }
                
                cookieAndUserId = Option<Sensor.Domain.ValueObject.UserIdAndToken>.With(new () {
                    UserId = userCookieOp.Unwrap().UserId,
                    UserToken = userCookieOp.Unwrap().Id
                });
            }

            var handlerOutput = await handler.HandlingAsync(dto, dbWrapper, apiProxy, cookieAndUserId);
            
            
            await dbWrapper.CommitAsync();
            return handlerOutput;
        }

        catch (Exception) {
            await dbWrapper.RollbackAsync();
            throw;
        }
        finally {
            try {
                await dbWrapper.DisposeAsync();
            }
            catch {
                // ignored
            }
        }
    }
}