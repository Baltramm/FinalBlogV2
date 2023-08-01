using FinalBlog.App.ViewModels.Tags.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.App.ViewModels.Tags
{
    public class TagCreateViewModel : ITagViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
