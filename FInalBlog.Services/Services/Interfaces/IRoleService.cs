using FinalBlog.Services.ViewModels.Roles.Request;
using FinalBlog.Services.ViewModels.Roles.Response;
using FinalBlog.Data.DBModels.Roles;

namespace FinalBlog.Services.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesByUserAsync(int userId);
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<RolesViewModel?> GetRolesViewModelAsync(int? userId);
        Task<bool> CreateRoleAsync(RoleCreateViewModel model);
        Task<List<Role>> GetAllRolesAsync();
        Task<Dictionary<string, bool>> GetEnabledRolesForUserAsync(int id);
        Task<RoleEditViewModel?> GetRoleEditViewModelAsync(int id);
        Task<bool> UpdateRoleAsync(Role role, RoleEditViewModel model);
        Task<bool> DeleteRoleAsync(int id);
        Task<RoleViewModel?> GetRoleViewModel(int id);
        Task<Dictionary<string, bool>> GetDictionaryRolesDefault();
    }
}
