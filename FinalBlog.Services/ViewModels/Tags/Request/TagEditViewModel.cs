﻿using FinalBlog.Services.ViewModels.Attributes;
using FinalBlog.Services.ViewModels.Tags.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ViewModels.Tags.Request
{
    /// <summary>
    /// Модель представления редактирования тега
    /// </summary>
    public class TagEditViewModel : ITagUpdateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [NotWhiteSpace(ErrorMessage = "Название тега не может содержать пробелов!")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
