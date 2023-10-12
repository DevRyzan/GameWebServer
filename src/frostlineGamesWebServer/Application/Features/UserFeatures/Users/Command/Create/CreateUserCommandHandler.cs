using MediatR;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities.Users;
using Core.Application.Generator;
using Application.Feature.UserFeatures.Users.Rules; 
using Domain.Entities.Files;
using Application.Services.UserServices.UserService;
using Application.Services.UserServices.UserDetailService;


namespace Application.Feature.UserFeatures.Users.Command.Create;


public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IUserDetailService _userDetailService; 
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public CreateUserCommandHandler(IUserService userService, IUserDetailService userDetailService, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _userDetailService = userDetailService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserEmailShouldBeNotExists(request.CreateUserDto.Email);

        User mappedUser = _mapper.Map<User>(request.CreateUserDto);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.CreateUserDto.Password, out passwordHash, out passwordSalt);
        mappedUser.PasswordHash = passwordHash;
        mappedUser.PasswordSalt = passwordSalt;
        mappedUser.Status = true;
        mappedUser.Code = UIDGenerator.GenerateUID(modelName: "USER");
      //  mappedUser.Email = request.CreateUserDto.Email;
        
        User createdUser = await _userService.Create(mappedUser);

        UserDetail createdUserDetail = new()
        {
            UserId = createdUser.Id,
            IsOnline = false,
            IsBanned = false,
            Code = UIDGenerator.GenerateUID(modelName: "USERDETAIL")
        };

        UserDetailImageFile userDetailImageFile = new()
        {
            Showcase = true,
            UserDetail = createdUserDetail,
            FileName = "defaultimage.png",
            Path = "user-images\\defaultimage.png",
            Storage = "LocalStorage",
            Code = UIDGenerator.GenerateUID(modelName: "File")
        };
 
        await _userDetailService.Create(createdUserDetail); 

        CreateUserCommandResponse response = _mapper.Map<CreateUserCommandResponse>(createdUser);

        //CreateUserCommandResponse response = new();

        //response.Id = createdUser.Id;
        //response.FirstName = createdUser.FirstName;
        //response.LastName = createdUser.LastName;   
        ////response.Email = createdUser.Email;
        //response.Status = createdUser.Status;
        //response.IsOnline = true; response;

        response.IsBanned = createdUserDetail.IsBanned;
        response.DeletedDate = createdUserDetail.DeletedDate;
        response.UpdatedDate = createdUserDetail.UpdatedDate;
        response.CreatedDate = createdUserDetail.CreatedDate;

        return response;
    }
}