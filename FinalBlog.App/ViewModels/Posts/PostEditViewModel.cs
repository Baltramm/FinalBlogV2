using FinalBlog.Data.DBModels.Tags;
using System.ComponentModel.DataAnnotations;

namespace FinalBlog.App.ViewModels.Posts
{
    public class PostEditViewModel:PostCreateViewModel
    {
        public int Id { get; set; }

        public string? ReturnUrl { get; set; }

       
    }
}
