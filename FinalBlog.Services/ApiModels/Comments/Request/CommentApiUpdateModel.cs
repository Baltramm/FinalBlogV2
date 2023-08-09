using FinalBlog.Services.ViewModels.Comments.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ApiModels.Comments.Request
{
    /// <summary>
    /// Модель обновления комментария для API
    /// </summary>
    public class CommentApiUpdateModel : ICommentEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Добавьте текст комментария!")]
        public string Text { get; set; }
    }
}
