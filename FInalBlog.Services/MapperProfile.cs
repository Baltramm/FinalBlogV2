using AutoMapper;
using FinalBlog.Services.ViewModels.Comments.Response;
using FinalBlog.Services.ViewModels.Posts.Request;
using FinalBlog.Services.ViewModels.Posts.Response;
using FinalBlog.Services.ViewModels.Roles.Request;
using FinalBlog.Services.ViewModels.Roles.Response;
using FinalBlog.Services.ViewModels.Tags.Request;
using FinalBlog.Services.ViewModels.Tags.Response;
using FinalBlog.Services.ViewModels.Users.Request;
using FinalBlog.Services.ViewModels.Users.Response;
using FinalBlog.Data.DBModels.Comments;
using FinalBlog.Data.DBModels.Posts;
using FinalBlog.Data.DBModels.Roles;
using FinalBlog.Data.DBModels.Tags;
using FinalBlog.Data.DBModels.Users;

namespace FinalBlog.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(m => m.Login))
                .ForMember(u => u.Email, opt => opt.MapFrom(m => m.EmailReg))
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(m => m.PasswordReg.GetHashCode()));
            CreateMap<User, UserEditViewModel>()
                .ForMember(u => u.Login, opt => opt.MapFrom(m => m.UserName));
            CreateMap<User, UserViewModel>();

            CreateMap<PostCreateViewModel, Post>();
            CreateMap<Post, PostEditViewModel>()
                .ForMember(m => m.PostTags, opt => opt.MapFrom(p => string.Join(" ", p.Tags.Select(p => p.Name))));
            CreateMap<Post, PostViewModel>();

            CreateMap<CommentCreateViewModel, Comment>();
            CreateMap<Comment, CommentEditViewModel>();

            CreateMap<TagCreateViewModel, Tag>();
            CreateMap<Tag, TagEditViewModel>();
            CreateMap<Tag, TagViewModel>();

            CreateMap<RoleCreateViewModel, Role>()
                .ForMember(m => m.NormalizedName, opt => opt.MapFrom(p => p.Name.ToUpper()));
            CreateMap<Role, RoleEditViewModel>();
            CreateMap<Role, RoleViewModel>();
        }
    }
}
