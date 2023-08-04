﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinalBlog.Services.Extensions;
using FinalBlog.Services.Services.Interfaces;
using FinalBlog.Services.ViewModels.Roles.Request;
using FinalBlog.Services.ViewModels.Roles.Response;
using FinalBlog.Data.DBModels.Roles;
using FinalBlog.Data.DBModels.Users;

namespace FinalBlog.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<Role>> GetRolesByUserAsync(int userId) =>
            await _roleManager.Roles.Include(r => r.Users)
                .SelectMany(r => r.Users, (r, u) => new { Role = r, UserId = u.Id })
                .Where(o => o.UserId == userId).Select(o => o.Role).ToListAsync();

        public async Task<Role?> GetRoleByNameAsync(string roleName) => await _roleManager.FindByNameAsync(roleName);

        public async Task<RolesViewModel?> GetRolesViewModelAsync(int? userId)
        {
            var model = new RolesViewModel();
            if (userId == null)
                model.Roles = await _roleManager.Roles.ToListAsync();
            else
            {
                var user = await _userManager.Users.Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null) return null;

                model.Roles = user.Roles;
            }

            return model;
        }

        public async Task<bool> CreateRoleAsync(RoleCreateViewModel model)
        {
            var role = _mapper.Map<Role>(model);
            var result = await _roleManager.CreateAsync(role);

            return result.Succeeded;
        }

        public async Task<Dictionary<string, bool>> GetEnabledRolesForUserAsync(int id)
        {
            var dictionary = new Dictionary<string, bool>();
            var userRoles = await _roleManager.Roles.Include(r => r.Users)
                .SelectMany(r => r.Users, (r, u) => new { r.Name, u.Id }).Where(o => o.Id == id)
                .Select(i => i.Name).ToListAsync();

            var allRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            var missRoles = allRoles.Except(userRoles);

            foreach (var role in missRoles)
            {
                if (role == null) continue;
                dictionary.Add(role, false);
            }
            foreach (var role in userRoles)
                dictionary.Add(role, true);

            return dictionary.OrderBy(p => p.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public async Task<RoleEditViewModel?> GetRoleEditViewModelAsync(int id)
        {
            var checkRole = await _roleManager.FindByIdAsync(id.ToString());
            if (checkRole == null)
                return null;

            return _mapper.Map<RoleEditViewModel>(checkRole);
        }

        public async Task<List<Role>> GetAllRolesAsync() => await _roleManager.Roles.ToListAsync();

        public async Task<bool> UpdateRoleAsync(Role role, RoleEditViewModel model)
        {
            role.Convert(model);
            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<RoleViewModel?> GetRoleViewModel(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return null;

            return _mapper.Map<RoleViewModel>(role);
        }

        public async Task<Dictionary<string, bool>> GetDictionaryRolesDefault()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var dict = new Dictionary<string, bool>();
            foreach (var role in roles)
            {
                if (role.Name == "User")
                    dict.Add(role.Name, true);
                else
                    dict.Add(role.Name!, false);
            }
            return dict;
        }
    }
}