using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SupportRequestFeatures.SupportRequestComments.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.CreateAdmin;

public class CreateAdminSupportRequestCommentCommandRequest : IRequest<CreateAdminSupportRequestCommentCommandResponse>, ISecuredRequest
{
    public CreateSupportRequestCommentDto CreateSupportRequestCommentDto { get; set; }
    public Guid UserId { get; set; }
    public string? UserIP { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestCommentAddAdmin };
}
