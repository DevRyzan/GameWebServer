using Application.Service.Repositories.FileRepositories;
using Application.Services.Repositories.UserRepositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Files;
using Domain.Entities.Users;
using MediatR;
using Microsoft.Extensions.Configuration;


namespace Application.Feature.UserFeatures.UserImageFile.Queries.GetUserImageByUserId
{
    public class GetUserImageByUserIdStatusTrueQueryHandler : IRequestHandler<GetUserImageByUserIdStatusTrueQueryRequest, GetListResponse<GetUserImageByUserIdStatusTrueQueryResponse>>
    {
        private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public GetUserImageByUserIdStatusTrueQueryHandler(IUserDetailImageFileRepository userDetailImageFileRepository, IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userDetailImageFileRepository = userDetailImageFileRepository;
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetUserImageByUserIdStatusTrueQueryResponse>> Handle(GetUserImageByUserIdStatusTrueQueryRequest request, CancellationToken cancellationToken)
        {

            UserDetail userDetail = await _userDetailRepository.GetAsync(x => x.UserId.Equals(request.UserId));

            IPaginate<UserDetailImageFile> paginate = await _userDetailImageFileRepository.GetListAsync(x => x.UserDetail.Id.Equals(request.UserId) && x.Status == true);

            GetListResponse<GetUserImageByUserIdStatusTrueQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetUserImageByUserIdStatusTrueQueryResponse>>(paginate);
            return mappedResponse;


        }
    }
}
