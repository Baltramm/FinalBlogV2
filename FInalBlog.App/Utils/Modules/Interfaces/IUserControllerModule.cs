using FinalBlog.App.Controllers;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Services.ViewModels.Users.Response;

namespace FinalBlog.App.Utils.Modules.Interfaces
{
    public interface IUserControllerModule
    {
        Task CheckDataAtCreationAsync(UserController controller, UserRegisterViewModel model);
        Task<User?> CheckDataAtLoginAsync(UserController controller, UserLoginViewModel model);
        Task<User?> CheckDataAtEditionAsync(UserController controller, UserEditViewModel model);
        Task<Dictionary<string, bool>> UpdateRoleStateForEditUserAsync(UserController controller);
    }
}
