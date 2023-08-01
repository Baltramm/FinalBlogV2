using FinalBlog.App.Controllers;
using FinalBlog.App.ViewModels.Posts;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Data.DBModels.Users;

namespace FinalBlog.App.Utils.Services.Interfaces
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreateViewModel model, List<Tag>? tags);
        Task<PostsViewModel> GetPostsViewModelAsync(int? userId);
        Task<PostViewModel?> GetPostViewModelAsync(int id);
        Task<PostEditViewModel?> GetPostEditViewModelAsync(int id, int? userId, bool fullAccess);
        Task<bool> DeletePostAsync(int id, int userId, bool fullAccess);
        Task<Post?> GetPostByIdAsync(int id);
        Task<bool> UpdatePostAsync(PostEditViewModel model, Post post);
        Task<Post?> CheckDataAtUpdatePostAsync(PostController controller, PostEditViewModel model);
    }
}
