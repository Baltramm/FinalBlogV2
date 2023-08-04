using FinalBlog.App.Controllers;
using FinalBlog.Data.DBModels.Roles;
using FinalBlog.Services.ViewModels.Roles.Response;

namespace FinalBlog.App.Utils.Modules.Interfaces
{
    public interface IRoleControllerModule
    {
        Task<Role?> CheckDataForCreateAsync(RoleController controller, RoleCreateViewModel model);
        Task<Role?> CheckDataAtEditAsync(RoleController controller, RoleEditViewModel model);
    }
}
