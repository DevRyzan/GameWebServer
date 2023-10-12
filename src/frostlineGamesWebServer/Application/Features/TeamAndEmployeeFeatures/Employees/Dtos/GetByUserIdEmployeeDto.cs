using Core.Application.Requests;

namespace Application.Feature.TeamAndEmployeeFeatures.Employees.Dtos
{
    public class GetByUserIdEmployeeDto
    {
        public Guid UserId { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
