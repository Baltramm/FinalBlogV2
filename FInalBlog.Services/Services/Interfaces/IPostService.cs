﻿using FinalBlog.Services.ViewModels.Posts.Request;
using FinalBlog.Services.ViewModels.Posts.Response;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Tags;

namespace FinalBlog.Services.Services.Interfaces
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreateViewModel model, List<Tag>? tags);
        Task<PostsViewModel> GetPostsViewModelAsync(int? tagId, int? userId);
        Task<PostViewModel?> GetPostViewModelAsync(int id, string userId);
        Task<PostEditViewModel?> GetPostEditViewModelAsync(int id, int? userId, bool fullAccess);
        Task<bool> DeletePostAsync(int id, int userId, bool fullAccess);
        Task<Post?> GetPostByIdAsync(int id);
        Task<bool> UpdatePostAsync(PostEditViewModel model, Post post);
        Task<int> GetLastCreatePostIdByUserId(int userId);
    }
}