using Microsoft.AspNetCore.Identity;
using FinalBlog.App.Controllers;
using FinalBlog.App.Utils.Modules.Interfaces;
using FinalBlog.Data.DBModels.Roles;
using FinalBlog.Services.ViewModels.Roles.Response;

namespace FinalBlog.App.Utils.Modules
{
    public class RoleControllerModule : IRoleControllerModule
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleControllerModule(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Role?> CheckDataAtEditAsync(RoleController controller, RoleEditViewModel model)
        {
            var checkRole = await _roleManager.FindByIdAsync(model.Id.ToString());
            if (checkRole == null)
                controller.ModelState.AddModelError(string.Empty, $"Роль с Id [{model.Id}] не найдена!");

            return checkRole;
        }

        public async Task<Role?> CheckDataForCreateAsync(RoleController controller, RoleCreateViewModel model)
        {
            var checkRole = await _roleManager.FindByNameAsync(model.Name);
            if (checkRole != null)
                controller.ModelState.AddModelError(string.Empty, $"Роль с именем [{model.Name}] уже существует!");

            return checkRole;
        }
    }
}
