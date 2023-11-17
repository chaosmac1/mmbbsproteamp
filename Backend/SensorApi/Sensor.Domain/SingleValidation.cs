namespace Sensor.Domain; 

public static class SingleValidation {
    public static bool IotIdIsNotValid(string? iotId) {
        if (iotId is null) return true;
        if (iotId.Length <= 2) return true;
        
        return false;
    }

    public static bool PasswordIsNotValid(string? value) {
        if (value is null) return true;
        if (value.Length <= 5) return true;
        
        return false;
    }
    
    public static bool UsernameIsNotValid(string? value) {
        if (value is null) return true;
        if (value.Length <= 4) return true;
        return false;
    }
}