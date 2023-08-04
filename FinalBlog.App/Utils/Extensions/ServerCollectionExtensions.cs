using FinalBlog.App.Utils.Modules;
using FinalBlog.App.Utils.Modules.Interfaces;
using FinalBlog.Data.Repositories;
using FinalBlog.Data.Repositories.Interfaces;
using FinalBlog.Services.Services;
using FinalBlog.Services.Services.Interfaces;

namespace FinalBlog.App.Utils.Extensions
{
    public static class ServerCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ITagService, TagService>();

            return services;
        }

        public static IServiceCollection AddControllerModules(this IServiceCollection services)
        {
            services.AddScoped<IUserControllerModule, UserControllerModule>();
            services.AddScoped<IRoleControllerModule, RoleControllerModule>();
            services.AddScoped<IPostControllerModule, PostControllerModule>();
            services.AddScoped<ITagControllerModule, TagControllerModule>();

            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, TRepoitory>(this IServiceCollection services)
            where TEntity : class
            where TRepoitory : Repository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, TRepoitory>();

            return services;
        }
    }
}
