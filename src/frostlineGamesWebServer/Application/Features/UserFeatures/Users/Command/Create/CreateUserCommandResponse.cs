using Core.Application.Dtos; 
namespace Application.Feature.UserFeatures.Users.Command.Create;

public class CreateUserCommandResponse : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public bool IsOnline { get; set; }
    public bool? IsBanned { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LoggedDate { get; set; }
}
