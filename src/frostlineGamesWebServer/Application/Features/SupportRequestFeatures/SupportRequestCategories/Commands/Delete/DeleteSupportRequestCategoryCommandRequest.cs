using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestCategories.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Delete;

public class DeleteSupportRequestCategoryCommandRequest : IRequest<DeleteSupportRequestCategoryCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestCategoryRemove };
}
