using FinalBlog.App.ViewModels.Roles;
using FinalBlog.Data.DBModels.Roles;

namespace FinalBlog.App.Utils.Extensions
{
    public static class RoleExtensions
    {
        public static Role Convert(this Role role, RoleEditViewModel model)
        {
            role.Name = model.Name;
            role.Description = model.Description;

            return role;
        }
    }
}
