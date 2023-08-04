using FinalBlog.Data.DBModels.Comments;

namespace FinalBlog.Services.ViewModels.Comments.Request
{
    public class CommentsViewModel
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
