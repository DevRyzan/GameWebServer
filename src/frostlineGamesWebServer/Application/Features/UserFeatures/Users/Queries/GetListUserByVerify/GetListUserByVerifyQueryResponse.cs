using Core.Application.Dtos;


namespace Application.Feature.UserFeatures.Users.Queries.GetListUserByVerify;

public class GetListUserByVerifyQueryResponse : IDto
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}
