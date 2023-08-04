using FinalBlog.Services.ViewModels.Comments.Response;
using FinalBlog.Data.DBModels.Comments;

namespace FinalBlog.Services.Extensions
{
    public static class CommentExtensions
    {
        public static Comment Convert(this Comment comment, CommentEditViewModel model)
        {
            comment.Text = model.Text;
            comment.UserId = model.UserId;

            return comment;
        }
    }
}
