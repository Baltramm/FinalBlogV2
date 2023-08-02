using System.ComponentModel.DataAnnotations;

namespace FinalBlog.App.ViewModels.Users
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Display(Name = "Отчество")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailReg { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(30, ErrorMessage = "Минимальная длина пароля: {2}, Максимальная: {1}", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-ZА-Яа-яa-z])(?=.*\d)[A-ZА-Яа-яa-z\d]{8,}$", ErrorMessage ="Слишком легкий пароль, добавьте буквы и цифры")]
    
        public string PasswordReg { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Compare("PasswordReg", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
