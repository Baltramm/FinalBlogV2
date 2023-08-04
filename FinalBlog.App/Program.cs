using Microsoft.EntityFrameworkCore;
using FinalBlog.App.Utils.Extensions;
using FinalBlog.Data;
using FinalBlog.Data.DBModels.Comments;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Data.DBModels.Users;
using FinalBlog.Data.Repositories;
using System.Reflection;
using FinalBlog.Data.DBModels.Roles;
using FinalBlog.Services;
using Microsoft.AspNetCore.Http.Extensions;

namespace FinalBlog.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<FinalBlogContext>(opt => opt.UseSqlite(connectionString, b => b.MigrationsAssembly("FinalBlog.Data")))
                .AddUnitOfWork()
                .AddCustomRepository<Post, PostRepository>()
                .AddCustomRepository<Comment, CommentRepository>()
                .AddCustomRepository<Tag, TagRepository>()
                .AddAppServices()
                .AddControllerModules();

            var assembly = Assembly.GetAssembly(typeof(MapperProfile));
            builder.Services.AddAutoMapper(assembly);

            builder.Services.AddIdentity<User, Role>(cfg =>
            {
                cfg.Password.RequiredLength = 8;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<FinalBlogContext>();

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Login";
                opt.AccessDeniedPath = "/AccessDenied";
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseCustomExceptionHandler();
            app.UseFollowLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStatusCodePages(async statusCodeContext =>
            {
                var response = statusCodeContext.HttpContext.Response;

                response.ContentType = "text/plain; charset=UTF-8";
                if (response.StatusCode == 400)
                    response.Redirect("/BadRequest");

                else if (response.StatusCode == 404)
                    response.Redirect("/NotFound");

                else if (response.StatusCode == 401)
                {
                    var returnUrl = statusCodeContext.HttpContext.Request.GetEncodedPathAndQuery().Replace("/", "%2F");
                    response.Redirect($"/Login?ReturnUrl={returnUrl}");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
