using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Feature.TeamFeatures.Employees.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Create
{
    public class CreateEmployeeCommandRequest : IRequest<CreatedEmployeeCommandResponse>, ISecuredRequest, ITransactionalRequest
    {
        public Guid UserId { get; set; }

        public string[] Roles => new[] { Admin, EmployeeAdd };

    }
}
