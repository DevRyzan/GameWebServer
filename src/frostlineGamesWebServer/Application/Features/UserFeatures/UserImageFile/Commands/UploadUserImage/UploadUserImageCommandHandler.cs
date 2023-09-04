using Application.Abstraction.Storage;
using Application.Feature.UserFeatures.UserImageFile.Rule;
using Application.Service.Repositories.FileRepositories;
using Application.Service.UserDetailService;
using Core.Application.Generator;
using Domain.Entities.Users;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Feature.UserFeatures.UserImageFile.Commands.UploadUserImage
{
    public class UploadUserImageCommandHandler : IRequestHandler<UploadUserImageCommandRequest, UploadUserImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly UserImageBusinessRule _userImageBusinessRule;

        public UploadUserImageCommandHandler(IStorageService storageService, IUserDetailService userDetailService, IUserDetailImageFileRepository userDetailImageFileRepository, IMemoryCache memoryCache, UserImageBusinessRule userImageBusinessRule)
        {
            _storageService = storageService;
            _userDetailService = userDetailService;
            _userDetailImageFileRepository = userDetailImageFileRepository;
            _memoryCache = memoryCache;
            _userImageBusinessRule = userImageBusinessRule;
        }

        public async Task<UploadUserImageCommandResponse> Handle(UploadUserImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _userImageBusinessRule.UserIdShouldExist(request.UserId);

            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("user-images", request.Files);

            UserDetail userDetail = await _userDetailService.GetByUserId(request.UserId);

            await _userDetailImageFileRepository.AddRangeAsync(result.Select(r => new Domain.Entities.Files.UserDetailImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Status = true,
                Code = UIDGenerator.GenerateUID(modelName: "USER-FILE"),
                Storage = _storageService.StorageName,
                UserDetail = userDetail,
                Showcase = true
            }).ToList());


            foreach (var file in request.Files)
            {
                _memoryCache.Remove(file);
            }

            return new();
        }
    }
}
