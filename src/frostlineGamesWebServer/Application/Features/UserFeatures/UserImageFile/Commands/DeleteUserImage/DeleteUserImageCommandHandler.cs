using Application.Feature.UserFeatures.UserImageFile.Rule;
using Application.Service.Repositories.FileRepositories;
using Domain.Entities.Files;
using MediatR;
using File = Domain.Entities.Files.File;

namespace Application.Feature.UserFeatures.UserImageFile.Commands.DeleteUserImage
{
    public class DeleteUserImageCommandHandler : IRequestHandler<DeleteUserImageCommandRequest, DeleteUserImageCommandResponse>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
        private readonly UserImageBusinessRule _userImageBusinessRule;

        public DeleteUserImageCommandHandler(IFileRepository fileRepository, IUserDetailImageFileRepository userDetailImageFileRepository, UserImageBusinessRule userImageBusinessRule)
        {
            _fileRepository = fileRepository;
            _userDetailImageFileRepository = userDetailImageFileRepository;
            _userImageBusinessRule = userImageBusinessRule;
        }

        public async Task<DeleteUserImageCommandResponse> Handle(DeleteUserImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _userImageBusinessRule.FileShouldBeExist(fileId: request.FileId);

            File file = await _fileRepository.GetAsync(x => x.Id.Equals(request.FileId));

            file.Status = false;
            file.DeletedDate = DateTime.UtcNow;
            await _fileRepository.UpdateAsyncTrackerClear(file);

            UserDetailImageFile userDetailImageFile = await _userDetailImageFileRepository.GetAsync(x => x.Id.Equals(file.Id));
            userDetailImageFile.Showcase = false;
            await _userDetailImageFileRepository.UpdateAsyncTrackerClear(userDetailImageFile);

            return new();

        }
    }
}
