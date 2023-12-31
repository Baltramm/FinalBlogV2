﻿using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Services.ViewModels.Posts.Request;
using Microsoft.AspNetCore.Mvc;
using FinalBlog.Data.DBModels.Roles;
using FinalBlog.Services.ViewModels.Roles.Request;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Services.ViewModels.Tags.Interfaces;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Services.ViewModels.Users.Request;
using FinalBlog.Services.ApiModels.Users.Request;
using FinalBlog.Services.ViewModels.Users.Intefaces;
using FinalBlog.Services.ApiModels.Roles.Request;

namespace FinalBlog.Services.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервисов проверки данных
    /// </summary>
    public interface ICheckDataService
    {
        /// <summary>
        /// Проверка сущностей по идентификаторам
        /// </summary>
        Task<List<string>> CheckEntitiesByIdAsync(int? postId = null, int? userId = null, int? roleId = null, int? tagId = null, int? commentId = null);


        /// <summary>
        /// Проверка данных полученных контроллером при обновлении статьи
        /// </summary>
        Task CheckDataForUpdatePostAsync(Controller controller, PostEditViewModel model);


        /// <summary>
        /// Проверка данных полученных контроллером при создании роли (основное приложение)
        /// </summary>
        Task CheckDataForCreateRoleAsync(Controller controller, RoleCreateViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при создании роли (API)
        /// </summary>
        Task<string> CheckDataForCreateRoleAsync(RoleCreateViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при редактировании роли (основное приложение)
        /// </summary>
        Task CheckDataForEditRoleAsync(Controller controller, RoleEditViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при редактировании роли (API)
        /// </summary>
        Task<string> CheckDataForEditRoleAsync(RoleEditViewModel model);
        /// <summary>
        /// Проверка изменения стандартных ролей приложения
        /// </summary>
        Task<bool> CheckChangeDefaultRolesAsync(int roleId, string roleName = "");


        /// <summary>
        /// Проверка данных о теге, полученных контроллером (основное приложение)
        /// </summary>
        Task CheckTagNameAsync<T>(Controller controller, T model) where T : ITagRequestViewModel;
        /// <summary>
        /// Проверка данных о теге, полученных контроллером (API)
        /// </summary>
        Task<string> CheckTagNameAsync<T>(T model) where T : ITagRequestViewModel;
        /// <summary>
        /// Проверка тегов на существование при создании статьи
        /// </summary>
        Task<List<string>> CheckTagsForCreatePostAsync(string tags);


        /// <summary>
        /// Проверка данных полученных контроллером при создании пользователя (основное приложение)
        /// </summary>
        Task CheckDataForCreateUserAsync(Controller controller, UserRegisterViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при создании пользователя (API)
        /// </summary>
        Task<List<string>> CheckDataForCreateUserAsync(UserRegisterViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при авторизации пользователя
        /// </summary>
        Task<User?> CheckDataForLoginAsync(Controller controller, UserLoginViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при редактировании пользователя (основное приложение)
        /// </summary>
        Task CheckDataForEditUserAsync(Controller controller, UserEditViewModel model);
        /// <summary>
        /// Проверка данных полученных контроллером при редактировании пользователя (API)
        /// </summary>
        Task<(User?, List<string>)> CheckDataForEditUserAsync(IUserUpdateModel model);
        /// <summary>
        /// Проверка корректности переданных ролей в модели обновления пользователя
        /// </summary>
        Task<List<string>> CheckRolesForUserChanged(List<string> roleNames);
    }
}
