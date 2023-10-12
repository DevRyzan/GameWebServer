using Core.Persistence.Repositories;

namespace Domain.Entities.Employees;

public class TeamAndEmployees : Entity<int>
{
    public int TeamId { get; set; }
    public Guid EmployeeId { get; set; }
    public Team Team { get; set; }
    public Employee Employee { get; set; }

    public TeamAndEmployees()
    {

    }
    //public TeamAndEmployees()
    //{
    //    TeamId = Convert.ToInt32(string.Empty);
    //    EmployeeId = Convert.ToInt32(string.Empty);
    //}

    public TeamAndEmployees(int teamId, Guid employeeId, Team team, Employee employee)
    {
        TeamId = teamId;
        EmployeeId = employeeId;
        Team = team;
        Employee = employee;
    }

    public TeamAndEmployees(int id, int teamId, Guid employeeId, Team team, Employee employee) : base(id)
    {
        Id = id;
        TeamId = teamId;
        EmployeeId = employeeId;
        Team = team;
        Employee = employee;
    }
}
