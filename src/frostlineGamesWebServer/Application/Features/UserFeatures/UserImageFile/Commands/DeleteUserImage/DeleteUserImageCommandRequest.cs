using Core.Application.Transaction;
using MediatR;


namespace Application.Feature.UserFeatures.UserImageFile.Commands.DeleteUserImage
{
    public class DeleteUserImageCommandRequest : IRequest<DeleteUserImageCommandResponse>, ITransactionalRequest
    {
        public int FileId { get; set; }
    }
}
