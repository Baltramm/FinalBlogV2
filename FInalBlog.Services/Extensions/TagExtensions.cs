using FinalBlog.Services.ViewModels.Tags.Response;
using FinalBlog.Data.DBModels.Tags;

namespace FinalBlog.Services.Extensions
{
    public static class TagExtensions
    {
        public static Tag Convert(this Tag tag, TagEditViewModel model)
        {
            tag.Name = model.Name;

            return tag;
        }
    }
}
