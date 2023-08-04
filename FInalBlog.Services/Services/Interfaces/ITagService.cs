using FinalBlog.Services.ViewModels.Tags.Request;
using FinalBlog.Services.ViewModels.Tags.Response;
using FinalBlog.Data.DBModels.Tags;

namespace FinalBlog.Services.Services.Interfaces
{
    public interface ITagService
    {
        Task<TagsViewModel?> GetTagsViewModelAsync(int? tagId, int? postId);
        Task<Tag?> GetTagByIdAsync(int id);
        Task<Tag?> GetTagByNameAsync(string name);
        Task<List<Tag>> GetAllTagsAsync();
        Task<bool> CreateTagAsync(TagCreateViewModel model);
        Task<List<Tag>?> SetTagsForPostAsync(string? postTags);
        Task<TagEditViewModel?> GetTagEditViewModelAsync(int id);
        Task<bool> UpdateTagAsync(TagEditViewModel model);
        Task<bool> DeleteTagAsync(int id);
        Task<TagViewModel?> GetTagViewModelAsync(int id);
    }
}
