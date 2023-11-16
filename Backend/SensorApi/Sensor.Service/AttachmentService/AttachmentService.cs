using System.Diagnostics.CodeAnalysis;
using LamLibAllOver;
using Sensor.Core.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.AttachmentService;

public struct AttachmentService< 
    Input, 
    Dto,
    Validation, 
    Handler,
    HandlerOutput> 
    where Input: IInput, new()
    where Dto: IDto, IDtoFrom<Dto, Input>, new()
    where Validation: IValidation<Dto>, new()
    where HandlerOutput: IHandlerOutput, new()
    where Handler: IHandler<Dto, HandlerOutput>, new() {
    
    public async Task<StatusOutput<HandlerOutput>> RunAsync(
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
        IController controller,
        bool needCookie) {
        
        Dto dto = default;
        try {
            
            dto = Dto.From(request);
            var validation = new Validation();
            if (!validation.Validate(dto)) {
                return StatusOutput<HandlerOutput>.AsBadRequest();
            }
        }
        catch (Exception) {
            return StatusOutput<HandlerOutput>.AsBadRequest();
        }
        
        
        var handler = new Handler();
        var dbWrapper = await DbWrapper.BuildAsync();
        
        try {
            Option<IUserIdAndToken> cookieAndUserId = default;
            if (needCookie) {
                var cookieOp = controller.GetCookie();
                if (cookieOp.IsNotSet()) {
                    await dbWrapper.RollbackAsync();    
                    return StatusOutput<HandlerOutput>.AsForbidden();
                }

                var token = await Core.Manager.CookieTokenManager
                                      .GetCookieByTokenAsync(dbWrapper.Db, cookieOp.Unwrap().Value);
                if (token.IsNotSet()) {
                    await dbWrapper.RollbackAsync();    
                    return StatusOutput<HandlerOutput>.AsForbidden();
                }
                
                cookieAndUserId = Option<IUserIdAndToken>.With(new DtoUserIdAndToken() {
                    CookieToken = token.Unwrap().UserToken.Value,
                    UserId = token.Unwrap().UserId.Value
                });
            }

            var handlerOutput = await handler.HandlingAsync(dto, dbWrapper, controller, cookieAndUserId);
            
            
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