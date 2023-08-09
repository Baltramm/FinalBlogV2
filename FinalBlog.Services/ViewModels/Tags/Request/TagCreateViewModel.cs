using FinalBlog.Services.ViewModels.Attributes;
using FinalBlog.Services.ViewModels.Tags.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.Services.ViewModels.Tags.Request
{
    /// <summary>
    /// Модель представления создания тега
    /// </summary>
    public class TagCreateViewModel : ITagRequestViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [NotWhiteSpace(ErrorMessage = "Название тега не может содержать пробелов!")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
