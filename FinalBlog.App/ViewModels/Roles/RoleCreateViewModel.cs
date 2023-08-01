﻿using System.ComponentModel.DataAnnotations;

namespace FinalBlog.App.ViewModels.Roles
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }
    }
}
