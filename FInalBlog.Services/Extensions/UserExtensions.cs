using FinalBlog.Services.ViewModels.Users.Request;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Services.ViewModels.Users.Intefaces;

namespace FinalBlog.Services.Extensions
{
    /// <summary>
    /// Расширения пользователя
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// Присвоение значений модели редактирования сущности пользователя
        /// </summary>
        public static User Convert(this User user, IUserUpdateModel model)
        {
            user.FirstName = model.FirstName;
            user.SecondName = model.SecondName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Login;
            user.BirthDate = model.BirthDate;
            user.Photo = model.Photo;

            return user;
        } 
    }
}
