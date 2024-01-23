namespace BearerJWT;

public class UserLoginDto
{
    public string Username { get; init; }
    public string Password { get; init; }
    
    public UserLoginDto(string username, string password)
    {
        Username = username;
        Password = password;
    }
}