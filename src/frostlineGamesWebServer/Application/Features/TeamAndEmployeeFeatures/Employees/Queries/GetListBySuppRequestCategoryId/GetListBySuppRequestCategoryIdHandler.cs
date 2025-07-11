﻿using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using Application.Services.Repositories.FileRepositories;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities.Employees;
using Domain.Entities.Files;
using Domain.Entities.Users;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListBySuppRequestCategoryId;

public class GetListBySRCategoryIdAndTeamIdHandler : IRequestHandler<GetListBySuppRequestCategoryIdRequest, GetListResponse<GetListBySuppRequestCategoryIdResponse>>
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IUserDetailService _userDetailService;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
    private readonly IUserService _userService;

    public GetListBySRCategoryIdAndTeamIdHandler(IEmployeeService employeeService, IMapper mapper, EmployeeBusinessRules employeeBusinessRules, IUserDetailService userDetailService, IUserDetailImageFileRepository userDetailImageFileRepository, IUserService userService)
    {
        _employeeService = employeeService;
        _mapper = mapper;
        _employeeBusinessRules = employeeBusinessRules;
        _userDetailService = userDetailService;
        _userDetailImageFileRepository = userDetailImageFileRepository;
        _userService = userService;
    }

    public async Task<GetListResponse<GetListBySuppRequestCategoryIdResponse>> Handle(GetListBySuppRequestCategoryIdRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.EmployeeShouldBeListedWhenSelected(request.GetListBySuppRequestCategoryIdDto.PageRequest.Page, request.GetListBySuppRequestCategoryIdDto.PageRequest.PageSize);

        IPaginate<Employee> employeeList = await _employeeService.GetListBySRCategoryIdAndTeamId(sRCategoryId: request.GetListBySuppRequestCategoryIdDto.SupportRequestCategoryId, index: request.GetListBySuppRequestCategoryIdDto.PageRequest.Page, size: request.GetListBySuppRequestCategoryIdDto.PageRequest.PageSize);

        List<User> users = new List<User>();
        List<UserDetail> userDetails = new List<UserDetail>();
        List<UserDetailImageFile> images = new List<UserDetailImageFile>();


        foreach (var item in employeeList.Items)
        {
            userDetails.Add(await _userDetailService.GetByUserId(item.UserId));
            users.Add(await _userService.GetById(item.UserId));
        }

        foreach (var item in userDetails)
        {
            images.Add(await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.Id)));
        }

        GetListResponse<GetListBySuppRequestCategoryIdResponse> mappedList = _mapper.Map<GetListResponse<GetListBySuppRequestCategoryIdResponse>>(employeeList);


        for (int i = 0; i < mappedList.Items.Count; i++)
        {
            var item = mappedList.Items[i];
            var image = images[i];
            item.UserName = users[i].FirstName + " " + users[i].LastName;
            item.UserImagePath = image != null ? image.Path.Replace('\\', '/') : "user-images/defaultimage.png";

        }
        return mappedList;
    }
}
