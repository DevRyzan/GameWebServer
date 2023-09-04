namespace Application.Feature.UserFeatures.Users.Dtos;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }

}
