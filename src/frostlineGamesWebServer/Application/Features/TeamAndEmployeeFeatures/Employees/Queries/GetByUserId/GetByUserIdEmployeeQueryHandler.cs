using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using Application.Services.UserServices.UserService;
using Application.Services.UserServices.UserDetailService;
using Application.Services.Repositories.FileRepositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Employees;
using Domain.Entities.Files;
using Domain.Entities.Users;
using MediatR;


namespace Application.Features.TeamFeatures.Employees.Queries.GetByUserId
{
    public class GetByUserIdEmployeeQueryHandler : IRequestHandler<GetByUserIdEmployeeQueryRequest, GetByUserIdEmployeeQueryResponse>
    {
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
        private readonly IUserService _userService;

        public GetByUserIdEmployeeQueryHandler(EmployeeBusinessRules employeeBusinessRules, IMapper mapper, IEmployeeService employeeService, IUserDetailService userDetailService, IUserDetailImageFileRepository userDetailImageFileRepository, IUserService userService)
        {
            _employeeBusinessRules = employeeBusinessRules;
            _mapper = mapper;
            _employeeService = employeeService;
            _userDetailService = userDetailService;
            _userDetailImageFileRepository = userDetailImageFileRepository;
            _userService = userService;
        }

        public async Task<GetByUserIdEmployeeQueryResponse> Handle(GetByUserIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            await _employeeBusinessRules.UserShouldBeExist(request.GetByUserIdEmployeeDto.UserId);
            Employee employee = await _employeeService.GetByUserId(request.GetByUserIdEmployeeDto.UserId);

            User user = await _userService.GetById(employee.UserId);
            UserDetail userDetail = await _userDetailService.GetByUserId(employee.UserId);
            UserDetailImageFile userDetailImageFile = await _userDetailImageFileRepository.GetAsync(x => x.Id.Equals(userDetail.Id));

            GetByUserIdEmployeeQueryResponse mappedResponse = _mapper.Map<GetByUserIdEmployeeQueryResponse>(employee);

            mappedResponse.UserName = user.FirstName + " " + user.LastName;
            mappedResponse.UserImagePath = userDetailImageFile != null ? userDetailImageFile.Path.Replace('\\', '/') : "user-images/defaultimage.png";
            mappedResponse.Code = user.Code;
            mappedResponse.CreatedDate = user.CreatedDate;
            mappedResponse.UpdatedDate = user.UpdatedDate;

            return mappedResponse;
        }
    }
}
