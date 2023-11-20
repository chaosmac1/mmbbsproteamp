namespace Sensor.Domain; 

public static class SingleValidation {
    public static bool IotNameIsNotValid(string? name) {
        if (name is null) return true;
        if (name.Length <= 2) return true;
        
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