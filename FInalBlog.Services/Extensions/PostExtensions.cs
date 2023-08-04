using FinalBlog.Services.ViewModels.Posts.Response;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Tags;
using System.Text.RegularExpressions;

namespace FinalBlog.Services.Extensions
{
    public static class PostExtensions
    {
        public static Post Convert(this Post post, PostEditViewModel model)
        {
            post.Title = model.Title;
            post.Content = model.Content;

            return post;
        }
    }
}
