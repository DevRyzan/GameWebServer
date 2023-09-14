namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveForAssignedUserInformation;

public class GetListByActiveForAssignedUserInformationQueryResponse
{
    public Guid AssignedUserId { get; set; }
    public string AssignedUserImagePath { get; set; }
    public string AssignedUserName { get; set; }
    public int UserDetailId { get; set; }
    public DateTime? AssignedTime { get; set; }
}
