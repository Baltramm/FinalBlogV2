﻿using FinalBlog.Services.ViewModels.Attributes;
using FinalBlog.Services.ViewModels.Tags.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ViewModels.Tags.Response
{
    public class TagEditViewModel : ITagResponseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [NotWhiteSpace(ErrorMessage = "Название тега не может содержать пробелов!")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}