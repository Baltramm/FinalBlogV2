using FinalBlog.App.Utils.Middlewares;

namespace FinalBlog.App.Utils.Extensions
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();
            return builder;
        }

        public static IApplicationBuilder UseFollowLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<FollowLoggingMiddleware>();
            return builder;
        }
    }
}
