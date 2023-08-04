using FinalBlog.App.Controllers;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Services.ViewModels.Tags.Interfaces;

namespace FinalBlog.App.Utils.Modules.Interfaces
{
    public interface ITagControllerModule
    {
        Task<Tag?> CheckTagNameAsync<T>(TagController controller, T model) where T : ITagResponseViewModel;
    }
}
