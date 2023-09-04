using Core.Persistence.Repositories;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Domain.Entities.Files;

public class File : Entity<int>
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
    public File()
    {
        
    }
    //public File()
    //{
    //    FileName = string.Empty;
    //    Path = string.Empty;
    //    Storage = string.Empty;
    //}
    public File(string fileName, string path, string storage)
    {
        FileName = fileName;
        Path = path;
        Storage = storage;
    }

    public File(int id ,string fileName, string path, string storage) : base()
    {
        Id = id;
        FileName = fileName;
        Path = path;
        Storage = storage;
    }

    //[NotMapped]
    //public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}
