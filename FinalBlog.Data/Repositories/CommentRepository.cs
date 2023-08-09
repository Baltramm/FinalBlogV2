using Microsoft.EntityFrameworkCore;
using FinalBlog.Data.DBModels.Comments;

namespace FinalBlog.Data.Repositories
{
    /// <summary>
    /// Репозиторий комментариев
    /// </summary>
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(FinalBlogContext context) : base(context) { }

        public override async Task<List<Comment>> GetAllAsync() => 
            await Set.Include(o => o.User).Include(o => o.Post).ToListAsync();

        /// <summary>
        /// Получение списка комментариев указанной статьи
        /// </summary>
        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId) =>
            await Set.Include(o => o.User).Include(o => o.Post).Where(c => c.PostId == postId).ToListAsync();

        /// <summary>
        /// Получение списка комментариев указанного пользователя
        /// </summary>
        public async Task<List<Comment>> GetCommentsByUserIdAsync(int userId) =>
            await Set.Include(o => o.User).Include(o => o.Post).Where(c => c.UserId == userId).ToListAsync();
    }
}
