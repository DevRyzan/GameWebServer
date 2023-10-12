using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;


namespace Application.Feature.UserFeatures.Users.Queries.GetListByActive
{
    public class GetListByActiveQueryHandler : IRequestHandler<GetListByActiveQueryRequest, GetListResponse<GetListByActiveQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetListByActiveQueryHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GetListResponse<GetListByActiveQueryResponse>> Handle(GetListByActiveQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<User> paginate = await _userService.GetByActiveList(request.PageRequest.Page, request.PageRequest.PageSize);

            GetListResponse<GetListByActiveQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByActiveQueryResponse>>(paginate);
            return mappedResponse;
        }
    }
}
