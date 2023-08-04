using FinalBlog.Data.DBModels.Tags;

namespace FinalBlog.Services.ViewModels.Tags.Request
{
    public class TagsViewModel
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
