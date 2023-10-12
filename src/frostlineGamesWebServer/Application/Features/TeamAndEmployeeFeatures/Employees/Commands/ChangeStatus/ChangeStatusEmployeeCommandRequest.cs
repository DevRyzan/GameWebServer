using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.ChangeStatus;

public class ChangeStatusEmployeeCommandRequest : IRequest<ChangeStatusEmployeeCommandResponse>//, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    //public string[] Roles => new[] { Admin, EmployeeChangeStatus };

}
