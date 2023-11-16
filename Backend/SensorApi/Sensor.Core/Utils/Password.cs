namespace SensorLib.Utils; 

public static class Password {
    public static string CreateHash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password, 6);
    public static bool Valid(string password, string hash)
        => BCrypt.Net.BCrypt.Verify(password, hash);
}