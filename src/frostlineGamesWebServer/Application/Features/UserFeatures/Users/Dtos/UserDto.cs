namespace Application.Feature.UserFeatures.Users.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string PhoneNumber { get; set; }
    public string Adress { get; set; }
    public bool IsOnline { get; set; }
    public bool IsBanned { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LoggedDate { get; set; }
}