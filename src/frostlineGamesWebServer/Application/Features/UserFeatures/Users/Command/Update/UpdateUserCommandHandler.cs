using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Command.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdatedUserCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IUserDetailService _userDetailService;
    private readonly UserBusinessRules _userBusinessRules;

    public UpdateUserCommandHandler(IUserService userService, IMapper mapper, IUserDetailService userDetailService, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _mapper = mapper;
        _userDetailService = userDetailService;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<UpdatedUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {

        User user = await _userService.GetById(request.Id);
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        await _userService.Update(user);

        UserDetail userDetail = await _userDetailService.GetByUserId(request.Id);
        userDetail.PhoneNumber = request.PhoneNumber;
        userDetail.Adress = request.Address;
        await _userDetailService.Update(userDetail);


        UpdatedUserCommandResponse mappedResponse = _mapper.Map<UpdatedUserCommandResponse>(userDetail);
        mappedResponse.FirstName = user.FirstName;
        mappedResponse.LastName = user.LastName;
        mappedResponse.Email = user.Email;
        mappedResponse.Status = user.Status;

        return mappedResponse;

    }
}