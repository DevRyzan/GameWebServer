using Domain.Enums;
using MediatR;
using static Application.Features.SupportRequestFeatures.Tags.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Update;

public class UpdateTagCommandRequest : IRequest<UpdateTagCommandResponse>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TagPriority TagPriority { get; set; }
    public string[] Roles => new[] { Admin, TagUpdate };
}
