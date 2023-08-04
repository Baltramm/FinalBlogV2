using FinalBlog.Data.DBModels.Roles;

namespace FinalBlog.Services.ViewModels.Roles.Request
{
    public class RolesViewModel
    {
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
