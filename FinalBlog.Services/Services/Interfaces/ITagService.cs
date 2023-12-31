﻿using FinalBlog.Services.ViewModels.Tags.Response;
using FinalBlog.Services.ViewModels.Tags.Request;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Data.Repositories;

namespace FinalBlog.Services.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервисов сущности тега
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Получение модели всех тегов
        /// </summary>
        Task<TagsViewModel?> GetTagsViewModelAsync(int? tagId, int? postId);
        /// <summary>
        /// Получение тега по идентификатору
        /// </summary>
        Task<Tag?> GetTagByIdAsync(int id);
        /// <summary>
        /// Получение списка тегов для статьи
        /// </summary>
        Task<List<Tag>?> GetTagByPostAsync(int postId);
        /// <summary>
        /// Получение тега по имени
        /// </summary>
        Task<Tag?> GetTagByNameAsync(string name);
        /// <summary>
        /// Получение списка всех тегов
        /// </summary>
        Task<List<Tag>> GetAllTagsAsync();
        /// <summary>
        /// Создание тега
        /// </summary>
        Task<bool> CreateTagAsync(TagCreateViewModel model);
        /// <summary>
        /// Присвоение тегов посту
        /// </summary>
        Task<List<Tag>> SetTagsForPostAsync(string? postTags);
        /// <summary>
        /// Получение модели редактирования тега
        /// </summary>
        Task<TagEditViewModel?> GetTagEditViewModelAsync(int id);
        /// <summary>
        /// Обновление тега
        /// </summary>
        Task<bool> UpdateTagAsync(TagEditViewModel model);
        /// <summary>
        /// Удаление тега
        /// </summary>
        Task<bool> DeleteTagAsync(int id);
        /// <summary>
        /// Получение модели указанного тега
        /// </summary>
        Task<TagViewModel?> GetTagViewModelAsync(int id);
    }
}
