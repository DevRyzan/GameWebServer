using Core.Application.Transaction;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Application.Feature.UserFeatures.UserImageFile.Commands.UploadUserImage
{
    public class UploadUserImageCommandRequest : IRequest<UploadUserImageCommandResponse>, ITransactionalRequest
    {
        public Guid UserId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
