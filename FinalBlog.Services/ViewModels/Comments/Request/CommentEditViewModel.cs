using FinalBlog.Services.ViewModels.Attributes;
using FinalBlog.Services.ViewModels.Comments.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ViewModels.Comments.Request
{
    /// <summary>
    /// Модель представления редактирования комментария
    /// </summary>
    public class CommentEditViewModel : ICommentEditModel
    {
        public int Id { get; set; }
        public string? ReturnUrl { get; set; }

        [Required(ErrorMessage = "Добавьте текст комментария!")]
        [Display(Name = "Комментарий")]
        public string Text { get; set; }
    }
}
