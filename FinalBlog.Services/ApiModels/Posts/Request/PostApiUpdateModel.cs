using FinalBlog.Services.ViewModels.Posts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ApiModels.Posts.Request
{
    /// <summary>
    /// Модель создания статьи для API
    /// </summary>
    public class PostApiUpdateModel : IPostUpdateModel
    {
        public int Id { get; set; }
        public string? PostTags { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Добавьте контент!")]
        public string Content { get; set; }
    }
}
