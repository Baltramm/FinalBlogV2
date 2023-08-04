using FinalBlog.Data.DBModels.Users;

namespace FinalBlog.Services.ViewModels.Users.Request
{
    public class UsersViewModel
    {
        public List<User> Users { get; set; } = new List<User>();
    }
}
