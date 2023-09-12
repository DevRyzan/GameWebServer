using Domain.Entities.Users;


namespace Domain.Entities.Files
{
    public class UserDetailImageFile : File
    {
        public bool Showcase { get; set; }
        public UserDetail UserDetail { get; set; }

    }
}
