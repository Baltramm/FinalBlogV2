using Microsoft.AspNetCore.Mvc;
using FinalBlog.App.Controllers;
using FinalBlog.App.ViewModels.Comments;
using FinalBlog.Data.DBModels.Comments;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Data.Repositories;

namespace FinalBlog.App.Utils.Services.Interfaces
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
