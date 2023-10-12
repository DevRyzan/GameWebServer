using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Models;

namespace Domain.Entities.Employees;
public class Team : Entity<int>
{
    public string Name { get; set; }
     
    public ICollection<SupportRequests.SupportRequestCategory> SupportRequestCategories { get; set; }

    public virtual ICollection<TeamAndEmployees>? TeamAndEmployees { get; set; }


    public Team()
    {
    }
    //public Team()
    //{
    //    Name = string.Empty;
    //}

    public Team(string name)
    {
        Name = name;
    }

    public Team(int id, string name) : base(id)
    {
        Id = id;
        Name = name;
    }
}
