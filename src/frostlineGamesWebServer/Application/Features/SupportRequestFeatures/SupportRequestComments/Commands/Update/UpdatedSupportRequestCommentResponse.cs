using Core.Application.Dtos; 

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Update;
public class UpdatedSupportRequestCommentResponse:IDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public string Comment { get; set; }
    public int BardId { get; set; } // Request Açan admin Staff harici herkesin bard olması beklenmekte
    public Guid UserId { get; set; }//Admin yorum yapabilir admin username ihticayı var 
    public int SupportRequestId { get; set; }
    public bool IsEdited { get; set; } // bu IsEdited Olavcak 
}
