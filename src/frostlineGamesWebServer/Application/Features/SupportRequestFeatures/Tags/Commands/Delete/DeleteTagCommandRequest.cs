using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.SupportRequestFeatures.Tags.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Delete;

public class DeleteTagCommandRequest : IRequest<DeletedTagCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, TagDelete };

}

