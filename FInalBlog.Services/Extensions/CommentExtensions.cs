using FinalBlog.Data.DBModels.Comments;
using FinalBlog.Services.ViewModels.Comments.Interfaces;

namespace FinalBlog.Services.Extensions
{
    /// <summary>
    /// Расширения для комментариев
    /// </summary>
    public static class CommentExtensions
    {
        /// <summary>
        /// Присвоение значений модели редактирования сущности комментария
        /// </summary>
        public static Comment Convert(this Comment comment, ICommentEditModel model)
        {
            comment.Text = model.Text;

            return comment;
        }
    }
}
