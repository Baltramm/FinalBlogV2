using Microsoft.AspNetCore.Identity;
using FinalBlog.Data.DBModels.Comments;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Roles;

namespace FinalBlog.Data.DBModels.Users
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }

        public List<Role> Roles { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Post> VisitedPosts { get; set; }

        public User()
        {
            Photo = "https://media.istockphoto.com/id/1277275885/ru/%D0%B2%D0%B5%D0%BA%D1%82%D0%BE%D1%80%D0%BD%D0%B0%D1%8F/%D0%B8%D0%BD%D1%82%D0%B5%D1%80%D0%BD%D0%B5%D1%82-%D1%80%D0%B0%D0%B1%D0%BE%D1%87%D0%B8%D1%85-%D0%BC%D0%B5%D1%81%D1%82-%D0%B7%D0%BD%D0%B0%D1%87%D0%BE%D0%BA-%D0%B2%D0%B5%D0%BA%D1%82%D0%BE%D1%80-%D1%87%D0%B5%D0%BB%D0%BE%D0%B2%D0%B5%D0%BA%D0%B0-%D1%81-%D0%BD%D0%BE%D1%83%D1%82%D0%B1%D1%83%D0%BA%D0%BE%D0%BC-%D0%BC%D1%83%D0%B6%D1%81%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D0%B5%D0%BB%D1%8C.jpg?s=170667a&w=0&k=20&c=bNrfbuCCyqnW7tsaIe2tzoQIcEB9_FlpiYl_YiGrrGM=";
        }
    }
}
