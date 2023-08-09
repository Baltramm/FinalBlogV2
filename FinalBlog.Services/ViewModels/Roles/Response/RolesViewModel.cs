using FinalBlog.Data.DBModels.Roles;

namespace FinalBlog.Services.ViewModels.Roles.Response
{
    /// <summary>
    /// Модель представления всех ролей
    /// </summary>
    public class RolesViewModel
    {
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
