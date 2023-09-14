using Domain.Entities.Users;


namespace Domain.Entities.Files
{
    public class UserDetailImageFile : File
    {
        public bool Showcase { get; set; }
        public UserDetail UserDetail { get; set; }


        public UserDetailImageFile()
        {

        }
        //public UserDetailImageFile()
        //{
        //    Showcase = false;
        //}

        public UserDetailImageFile(bool showcase, UserDetail userDetail)
        {
            Showcase = showcase;
            UserDetail = userDetail;
        }

        public UserDetailImageFile(int id, bool showcase, UserDetail userDetail) : base()
        {
            Id = id;
            Showcase = showcase;
            UserDetail = userDetail;
        }

    }
}
