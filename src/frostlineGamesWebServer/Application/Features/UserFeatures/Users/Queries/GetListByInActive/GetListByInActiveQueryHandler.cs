using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;


namespace Application.Feature.UserFeatures.Users.Queries.GetListByInActive
{
    public class GetListByInActiveQueryHandler : IRequestHandler<GetListByInActiveQueryRequest, GetListResponse<GetListByInActiveQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetListByInActiveQueryHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GetListResponse<GetListByInActiveQueryResponse>> Handle(GetListByInActiveQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<User> paginate = await _userService.GetByInActiveList(request.PageRequest.Page, request.PageRequest.PageSize);

            GetListResponse<GetListByInActiveQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByInActiveQueryResponse>>(paginate);
            return mappedResponse;

        }
    }
}
