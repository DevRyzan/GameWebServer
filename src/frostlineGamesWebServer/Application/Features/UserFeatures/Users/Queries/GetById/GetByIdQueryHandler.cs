using Application.Feature.UserFeatures.Users.Rules; 
using Application.Service.UserDetailService;
using Application.Service.UserService;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Files;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Queries.GetById;

public class GetByIdUserQueryHandler : IRequestHandler<GetByIdQueryRequest, GetByIdUserQueryResponse>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IUserDetailService _userDetailService; 

    public GetByIdUserQueryHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules, IUserDetailService userDetailService)
    {
        _userService = userService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _userDetailService = userDetailService; 
    }

    public async Task<GetByIdUserQueryResponse> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

        User? user = await _userService.GetById(request.Id);
        UserDetail userDetail = await _userDetailService.GetByUserId(user.Id);
        //UserDetailImageFile userDetailImageFiles = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(userDetail.Id));

        GetByIdUserQueryResponse userDto = _mapper.Map<GetByIdUserQueryResponse>(user);

        userDto.PhoneNumber = userDetail.PhoneNumber;
        userDto.NickName = user.FirstName + user.LastName;
        userDto.Address = userDetail.Adress;
        userDto.IsBanned = userDetail.IsBanned;
        userDto.DeletedDate = userDetail.DeletedDate;
        userDto.UpdatedDate = userDetail.UpdatedDate;
        userDto.CreatedDate = userDetail.CreatedDate;
        userDto.LoggedDate = userDetail.LoggedDate;
        //userDto.ImagePath = userDetailImageFiles != null ? userDetailImageFiles.Path.Replace('\\', '/') : "user-images/defaultimage.png";

        return userDto;
    }
}