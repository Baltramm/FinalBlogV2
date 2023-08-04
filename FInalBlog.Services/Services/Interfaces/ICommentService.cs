using FinalBlog.Services.ViewModels.Comments.Request;
using FinalBlog.Services.ViewModels.Comments.Response;
using FinalBlog.Data.DBModels.Comments;

namespace FinalBlog.Services.Services.Interfaces
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CommentCreateViewModel model);
        Task<CommentsViewModel> GetCommentsViewModelAsync(int? postId, int? userId);
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<List<Comment>> GetAllCommentsByPostIdAsync(int postId);
        Task<CommentEditViewModel?> GetCommentEditViewModelAsync(int id, int? userId, bool fullAccess);
        Task<bool> UpdateCommentAsync(CommentEditViewModel model);
        Task<bool> DeleteCommentAsync(int id, int? userId, bool fullAccess);
    }
}
