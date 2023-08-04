using FinalBlog.App.Controllers;
using FinalBlog.App.Utils.Modules.Interfaces;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Services.Services.Interfaces;
using FinalBlog.Services.ViewModels.Posts.Response;

namespace FinalBlog.App.Utils.Modules
{
    public class PostControllerModule : IPostControllerModule
    {
        private readonly IPostService _postService;

        public PostControllerModule(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Post?> CheckDataAtUpdateAsync(PostController controller, PostEditViewModel model)
        {
            var currentPost = await _postService.GetPostByIdAsync(model.Id);
            if (currentPost == null)
                controller.ModelState.AddModelError(string.Empty, $"Статья с Id [{model.Id}] не найдена!");

            return currentPost;
        }
    }
}
