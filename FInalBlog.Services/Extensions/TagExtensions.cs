using FinalBlog.Services.ViewModels.Tags.Request;
using FinalBlog.Data.DBModels.Tags;

namespace FinalBlog.Services.Extensions
{
    /// <summary>
    /// Расширения тега
    /// </summary>
    public static class TagExtensions
    {
        /// <summary>
        /// Присвоение значений модели редактирования сущности тега
        /// </summary>
        public static Tag Convert(this Tag tag, TagEditViewModel model)
        {
            tag.Name = model.Name;

            return tag;
        } 
    }
}
