using Sensor.Domain;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service; 

public static class ValidationParser {
    public static bool Validating<T>(T dto) where T : IDto {
        return dto switch {
            IInputAdminIotDelete @v => Valid(@v), 
            IInputAdminIotInsert @v => Valid(@v), 
            IInputAdminIotUpdate<ICanNull<string>> @v => Valid(@v), 
            IInputAdminSetUserPassword @v => Valid(@v), 
            IAmount @v => Valid(@v), 
            IInputIotLogin @v => Valid(@v), 
            IInputUpdatePassword @v => Valid(@v), 
            IInputUserAdd @v => Valid(@v), 
            IInputUserId @v => Valid(@v), 
            IInputUserLogin @v => Valid(@v),
            _ => throw new ArgumentOutOfRangeException(nameof(dto), dto, null)
        };
    }

    private static bool Valid(IInputAdminIotDelete value) {
        if (SingleValidation.IotIdIsNotValid(value.IotId)) return false;

        return true;
    }

    private static bool Valid(IInputAdminIotInsert value) {
        if (SingleValidation.IotIdIsNotValid(value.IotId)) return false;

        return true;
    }

    private static bool Valid(IInputAdminIotUpdate<ICanNull<string>> value) {
        if (SingleValidation.IotIdIsNotValid(value.IotId)) return false;
        if (!Valid(value.UpdateId, SingleValidation.IotIdIsNotValid)) return false;

        return true;
    }

    private static bool Valid(IInputAdminSetUserPassword value) {
        if (SingleValidation.PasswordIsNotValid(value.Password)) return false;
        if (value.UserId == default) return false;

        return true;
    }

    private static bool Valid(IAmount value) {
        if (value.Amount < 0) return false;

        return true;
    }

    private static bool Valid(ICanNull<string> value, Func<string, bool> validation) {
        // Null Is Valid
        if (value is null) return true;

        return validation(value.Value!);
    }

    private static bool Valid(IInputIotLogin value) {
        if (SingleValidation.PasswordIsNotValid(value.Password)) return false;
        if (SingleValidation.IotIdIsNotValid(value.IotName)) return false;

        return true;
    }

    private static bool Valid(IInputUpdatePassword value) {
        if (SingleValidation.PasswordIsNotValid(value.Password)) return false;
        
        return true;
    }

    private static bool Valid(IInputUserAdd value) {
        if (SingleValidation.PasswordIsNotValid(value.Password)) return false;
        if (SingleValidation.UsernameIsNotValid(value.Username)) return false;

        return true;
    }

    private static bool Valid(IInputUserId value) {
        if (value.UserId == default) return false;

        return true;
    }

    private static bool Valid(IInputUserLogin value) {
        if (SingleValidation.PasswordIsNotValid(value.Password)) return false;
        if (SingleValidation.UsernameIsNotValid(value.Username)) return false;

        return true;
    }
}