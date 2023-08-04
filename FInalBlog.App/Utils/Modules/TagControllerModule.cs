using FinalBlog.App.Controllers;
using FinalBlog.App.Utils.Modules.Interfaces;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Services.Services.Interfaces;
using FinalBlog.Services.ViewModels.Tags.Interfaces;
using FinalBlog.Services.ViewModels.Tags.Response;

namespace FinalBlog.App.Utils.Modules
{
    public class TagControllerModule : ITagControllerModule
    {
        private readonly ITagService _tagService;

        public TagControllerModule(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<Tag?> CheckTagNameAsync<T>(TagController controller, T model) where T : ITagResponseViewModel
        {
            var checkTag = await _tagService.GetTagByNameAsync(model.Name);
            var check = model is TagEditViewModel editModel
                ? (checkTag != null && checkTag.Id != editModel.Id) : checkTag != null;

            if (check)
                controller.ModelState.AddModelError(string.Empty, $"Тег с именем [{model.Name}] уже существует!");

            return checkTag;
        }
    }
}
