using FinalBlog.Data.DBModels.Posts;

namespace FinalBlog.Services.ViewModels.Posts.Response
{
    /// <summary>
    /// Модель представления всез статей
    /// </summary>
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
