using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCategoryRequest : IRequest<ChangeStatusSupportRequestCategoryResponse>//, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    //public string[] Roles => new[] { Admin, SupportRequestCategoryChangeStatus };

}
