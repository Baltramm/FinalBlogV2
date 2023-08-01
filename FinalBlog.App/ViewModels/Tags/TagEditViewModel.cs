using FinalBlog.App.ViewModels.Tags.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.App.ViewModels.Tags
{
    public class TagEditViewModel :TagCreateViewModel,ITagViewModel
    {
        public int Id { get; set; }

    }
}
