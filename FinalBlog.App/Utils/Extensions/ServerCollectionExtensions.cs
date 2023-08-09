using FinalBlog.Data.Repositories;
using FinalBlog.Data.Repositories.Interfaces;
using FinalBlog.Services.Services;
using FinalBlog.Services.Services.Interfaces;

namespace FinalBlog.App.Utils.Extensions
{
    /// <summary>
    /// Расширения для сервисов приложения
    /// </summary>
    public static class ServerCollectionExtensions
    {
        /// <summary>
        /// Добавление UnitOfWork в сервисы
        /// </summary>
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        /// <summary>
        /// Добавление сервисов бизнес-логики в сервисы приложения
        /// </summary>
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICheckDataService, CheckDataService>();

            return services;
        }

        /// <summary>
        /// Добавление кастомных репозиториев в сервисы
        /// </summary>
        public static IServiceCollection AddCustomRepository<TEntity, TRepoitory>(this IServiceCollection services) 
            where TEntity : class
            where TRepoitory : Repository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, TRepoitory>();

            return services;
        }
    }
}
