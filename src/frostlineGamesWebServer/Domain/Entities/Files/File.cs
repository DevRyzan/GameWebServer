using Core.Persistence.Repositories;

namespace Domain.Entities.Files;

public class File : Entity<int>
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }

}
