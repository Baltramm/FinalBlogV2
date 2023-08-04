using FinalBlog.Data.DBModels.Posts;

namespace FinalBlog.Services.ViewModels.Posts.Request
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
