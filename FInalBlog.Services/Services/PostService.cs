﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using FinalBlog.Services.Extensions;
using FinalBlog.Services.Services.Interfaces;
using FinalBlog.Services.ViewModels.Posts.Request;
using FinalBlog.Services.ViewModels.Posts.Response;
using FinalBlog.Services.ViewModels.Comments.Response;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Data.Repositories;
using FinalBlog.Data.Repositories.Interfaces;

namespace FinalBlog.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITagService _tagService;

        private readonly PostRepository _postRepository;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, ITagService tagService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _tagService = tagService;

            _postRepository = (PostRepository)_unitOfWork.GetRepository<Post>();
        }

        public async Task<bool> CreatePostAsync(PostCreateViewModel model, List<Tag>? tags)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null) return false;

            var post = _mapper.Map<Post>(model);
            post.User = user;
            if (tags != null) post.Tags = tags;

            await _postRepository.CreateAsync(post);
            return true;
        }

        public async Task<PostsViewModel> GetPostsViewModelAsync(int? tagId, int? userId)
        {
            var model = new PostsViewModel();

            if (userId == null && tagId == null)
                model.Posts = await _postRepository.GetAllAsync();
            else if (userId != null && tagId == null)
                model.Posts = await _postRepository.GetPostsByUserIdAsync((int)userId);
            else
                model.Posts = await _postRepository.GetPostsByTagIdAsync((int)tagId!);

            return model;
        }

        public async Task<PostEditViewModel?> GetPostEditViewModelAsync(int id, int? userId, bool fullAccess)
        {
            var post = await GetPostByIdAsync(id);
            var check = fullAccess
                ? post != null
                : post != null && post.UserId == (int)userId!;

            if (!check)
                return null;
            return _mapper.Map<PostEditViewModel>(post);
        }

        public async Task<Post?> GetPostByIdAsync(int id) => await _postRepository.GetAsync(id);

        public async Task<bool> DeletePostAsync(int id, int userId, bool fullAccess)
        {
            var post = await GetPostByIdAsync(id);
            var check = fullAccess
                ? post != null
                : post != null && post.UserId == userId;
            if (!check) return false;

            if (await _postRepository.DeleteAsync(post!) == 0) return false;

            return true;
        }

        public async Task<bool> UpdatePostAsync(PostEditViewModel model, Post post)
        {
            post.Convert(model);
            if (!string.IsNullOrEmpty(model.PostTags))
                post.Tags = await _tagService.SetTagsForPostAsync(model.PostTags) ?? new List<Tag>();

            await _postRepository.UpdateAsync(post);
            return true;
        }

        public async Task<PostViewModel?> GetPostViewModelAsync(int id, string userId)
        {
            var post = await _postRepository.GetAsync(id);
            var user = await _userManager.FindByIdAsync(userId);
            if (post == null || user == null) return null;

            if (!post.Users.Contains(user))
            {
                post.Users.Add(user);
                await _postRepository.UpdateAsync(post);
            }

            var model = _mapper.Map<PostViewModel>(post);
            model.CommentCreateViewModel = new CommentCreateViewModel { PostId = id };

            return model;
        }

        public async Task<int> GetLastCreatePostIdByUserId(int userId) => await _postRepository.FindLastCreateIdByUserId(userId);
    }
}