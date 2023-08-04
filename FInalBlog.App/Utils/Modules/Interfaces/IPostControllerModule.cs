using FinalBlog.App.Controllers;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Services.ViewModels.Posts.Response;

namespace FinalBlog.App.Utils.Modules.Interfaces
{
    public interface IPostControllerModule
    {
        Task<Post?> CheckDataAtUpdateAsync(PostController controller, PostEditViewModel model);
    }
}
