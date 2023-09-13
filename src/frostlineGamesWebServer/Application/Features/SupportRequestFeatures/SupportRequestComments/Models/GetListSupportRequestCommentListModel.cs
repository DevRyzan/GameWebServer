namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Models;

public class GetListSupportRequestCommentListModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public string Comment { get; set; }
    public Guid UserId { get; set; }
    public int SupportRequestId { get; set; }
    public bool IsDeleted { get; set; }
    public bool Status { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
