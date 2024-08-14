using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities.SupportRequests;
using Persistence.Models;

namespace Domain.Entities.Employees;

public class Employee : Entity<Guid>
{
    public Guid UserId { get; set; }
    public User User { get; set; }



     
    public virtual ICollection<TeamAndEmployees>? TeamAndEmployees { get; set; }
    public virtual ICollection<SupportRequests.SupportRequest> SupportRequest { get; set; }
    public Employee()
    {

    }
    //public Employee()
    //{
    //    UserId = Convert.ToInt32(string.Empty);
    //    TeamAndEmployees = new HashSet<TeamAndEmployees>();
    //}

    public Employee(Guid userId, User user, ICollection<TeamAndEmployees>? teamAndEmployees)
    {
        UserId = userId;
        User = user;
        TeamAndEmployees = teamAndEmployees;
    }
    public Employee(Guid id, Guid userId, User user, ICollection<TeamAndEmployees>? teamAndEmployees) : this()

    {
        Id = id;
        UserId = userId;
        User = user;
        TeamAndEmployees = teamAndEmployees;
    }
}