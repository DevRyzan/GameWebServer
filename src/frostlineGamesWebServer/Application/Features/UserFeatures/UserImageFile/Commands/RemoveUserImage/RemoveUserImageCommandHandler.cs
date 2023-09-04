using Application.Feature.UserFeatures.UserImageFile.Rule;
using Application.Service.Repositories.FileRepositories;
using Domain.Entities.Files;
using MediatR;


namespace Application.Feature.UserFeatures.UserImageFile.Commands.RemoveUserImage
{
    public class RemoveUserImageCommandHandler : IRequestHandler<RemoveUserImageCommandRequest, RemoveUserImageCommandResponse>
    {

        private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
        private readonly UserImageBusinessRule _userImageBusinessRule;

        public RemoveUserImageCommandHandler(IUserDetailImageFileRepository userDetailImageFileRepository, UserImageBusinessRule userImageBusinessRule)
        {
            _userDetailImageFileRepository = userDetailImageFileRepository;
            _userImageBusinessRule = userImageBusinessRule;
        }

        public async Task<RemoveUserImageCommandResponse> Handle(RemoveUserImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _userImageBusinessRule.FileShouldBeExist(fileId: request.FileId)
                ;

            UserDetailImageFile userDetailImageFile = await _userDetailImageFileRepository.GetAsync(x => x.Id.Equals(request.FileId));

            await _userDetailImageFileRepository.DeleteAsync(userDetailImageFile);

            return new();

        }
    }
}
