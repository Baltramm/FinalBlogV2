using System.ComponentModel.DataAnnotations;

namespace FinalBlog.App.ViewModels.Comments
{
    public class CommentEditViewModel:CommentCreateViewModel
    {
        public int Id { get; set; }
        public string? ReturnUrl { get; set; }

    }
}
