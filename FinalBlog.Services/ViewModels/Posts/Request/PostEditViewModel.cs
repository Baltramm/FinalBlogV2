﻿using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Services.ViewModels.Posts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ViewModels.Posts.Request
{
    /// <summary>
    /// Модель представления редактирования статьи
    /// </summary>
    public class PostEditViewModel : IPostUpdateModel
    {
        public int Id { get; set; }

        public string? ReturnUrl { get; set; }

        public List<Tag>? AllTags { get; set; }

        public string? PostTags { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Добавьте контент!")]
        [Display(Name = "Контент")]
        public string Content { get; set; }
    }
}
