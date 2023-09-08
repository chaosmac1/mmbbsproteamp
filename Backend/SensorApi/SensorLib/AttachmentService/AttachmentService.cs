using System.Diagnostics.CodeAnalysis;
using LamLibAllOver;
using SensorLib.AttachmentService.Interface;
using SensorLib.Class;
using SensorLib.Database;
using SensorLib.Record;

namespace SensorLib.AttachmentService; 


public struct AttachmentService< 
    Input, 
    Validation, 
    TranformHandler,
    HandlerInput,
    Handler,
    HandlerOutput,
    TransformOutput,
    Output> 
    where Validation: IValidation<Input>, new()
    where TranformHandler: IInputTransform<Input, HandlerInput>, new()
    where Handler: IHandler<HandlerInput, HandlerOutput>, new()
    where TransformOutput: IOutputTransform<HandlerOutput, Output>, new() 
    where HandlerOutput: IHandlerOutput 
    where Output: IView 
    where Input: IRequest {
    
    public async Task<StatusOutput<Output>> RunAsync(
        Input request, 
        IController controller,
        bool needCookie,
        [StringSyntax("Route")] string path,
        CancellationToken token = default) {
        
        try {
            var api = this;
            var task = Task
                       .Factory
                       .StartNew(() => api.RunFullAsync(
                           request, 
                           controller, 
                           needCookie, 
                           path), 
                           TaskCreationOptions.PreferFairness)
                       .Unwrap();
            
            await task.WaitAsync(token);
            if (task.IsCompleted == false)
                return StatusOutput<Output>.AsInternelServerError(TraceMsg.WithMessage("IsNotCompleted"));

            var result = task.Result;
            return result == EResult.Err 
                ? StatusOutput<Output>.AsInternelServerError(result.Err().ToString()) 
                : result.Ok();
        }
        catch (Exception e) {
            throw;
        }
    }

    private async Task<SResult<StatusOutput<Output>>> RunFullAsync(
        Input request, 
        IController controller,
        bool needCookie,
        string path) {
        
        var validation = new Validation();
        var tranformHandler = new TranformHandler();
        var handler = new Handler();
        var transformOutput = new TransformOutput();
        var dbWrapper = await DbWrapper.BuildAsync();
        
        try {
            Option<UserIdAndToken> cookieOp = default;
            if (needCookie) {
                cookieOp = await controller.GetCookieAndUserId(dbWrapper);
                if (cookieOp.IsNotSet()) {
                    await dbWrapper.RollbackAsync();    
                    return SResult<StatusOutput<Output>>.Ok(StatusOutput<Output>.AsForbidden());    
                }
            }
            
            var validateResult = await validation.Validate(request, dbWrapper);

            if (!validateResult) {
                await dbWrapper.RollbackAsync();
                return SResult<StatusOutput<Output>>.Ok(StatusOutput<Output>.AsBadRequest());
            }

        
            var handlerOutput = await handler.HandlingAsync(
                tranformHandler.Transform(request), 
                dbWrapper, 
                controller,
                cookieOp);
            
            await dbWrapper.CommitAsync();
            return SResult<StatusOutput<Output>>.Ok(transformOutput.Transform(handlerOutput));
        }

        catch (Exception e) {
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