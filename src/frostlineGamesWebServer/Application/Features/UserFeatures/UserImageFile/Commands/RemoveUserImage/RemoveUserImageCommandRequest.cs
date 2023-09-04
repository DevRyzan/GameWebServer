using Core.Application.Transaction;
using MediatR;


namespace Application.Feature.UserFeatures.UserImageFile.Commands.RemoveUserImage;

public class RemoveUserImageCommandRequest : IRequest<RemoveUserImageCommandResponse>, ITransactionalRequest
{
    public int FileId { get; set; }
}
