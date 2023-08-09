using FinalBlog.Data.DBModels.Comments;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Services.ViewModels.Comments.Request;

namespace FinalBlog.Services.ViewModels.Posts.Response
{
    /// <summary>
    /// Модель представления статьи
    /// </summary>
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }

        public CommentCreateViewModel CommentCreateViewModel { get; set; }
    }
}
