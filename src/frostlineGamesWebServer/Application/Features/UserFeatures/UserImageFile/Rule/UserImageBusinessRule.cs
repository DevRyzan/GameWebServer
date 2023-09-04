using Application.Feature.UserFeatures.UserImageFile.Constants;
using Application.Service.Repositories.FileRepositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules; 
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using File = Domain.Entities.Files.File;

namespace Application.Feature.UserFeatures.UserImageFile.Rule;

public class UserImageBusinessRule : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;
    private readonly IFileRepository _fileRepository;

    public UserImageBusinessRule(IUserRepository userRepository, IFileRepository fileRepository)
    {
        _userRepository = userRepository;
        _fileRepository = fileRepository;
    }

    public async Task UserIdShouldExist(Guid userId)
    {
        User? result = await _userRepository.GetAsync(b => b.Id.Equals(userId));
        if (result == null) throw new BusinessException(FileMessages.UserDontExists);

    }
    public async Task FileShouldBeExist(int fileId)
    {
        File file = await _fileRepository.GetAsync(x => x.Id.Equals(fileId));
        if (file == null) throw new BusinessException(FileMessages.FileDontExists);
    }
}
