using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Users;
using MediatR;


namespace Application.Feature.UserFeatures.Users.Queries.GetByEmail
{
    public class GetByEmailUserQueryHandler : IRequestHandler<GetByEmailUserQueryRequest, GetByEmailUserQueryResponse>
    {
        private readonly IUserService? _userService;
        private readonly IUserDetailService? _userDetailService;
        private readonly IMapper? _mapper;
        private readonly UserBusinessRules? _userBusinessRules;

        public GetByEmailUserQueryHandler(IUserService? userService, IUserDetailService? userDetailService, IMapper? mapper, UserBusinessRules? userBusinessRules)
        {
            _userService = userService;
            _userDetailService = userDetailService;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<GetByEmailUserQueryResponse> Handle(GetByEmailUserQueryRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EmailShouldBeExist(request.Email);

            User user = await _userService.GetByEmail(request.Email);
            UserDetail userDetail = await _userDetailService.GetByUserId(user.Id);

            GetByEmailUserQueryResponse mappedResponse = _mapper.Map<GetByEmailUserQueryResponse>(user);

            mappedResponse.UserId = user.Id;
            mappedResponse.BasketId = userDetail.BasketId;
            mappedResponse.PhoneNumber = userDetail.PhoneNumber;
            mappedResponse.Address = userDetail.Address;
            mappedResponse.IsOnline = userDetail.IsOnline;
            mappedResponse.IsBanned = userDetail.IsBanned;
            mappedResponse.LoggedDate = userDetail.LoggedDate;

            return mappedResponse;
        }
    }
}
