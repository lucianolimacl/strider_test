using Strider.Application.ViewModels;
using Strider.Common;
using Strider.Common.Filters;

namespace Strider.Application.Interfaces
{
    public interface IPostAppService
    {
        Task<Result<PostViewModel>> CreatePostAsync(CreatePostViewModel model);
        Task<Result<PostViewModel>> CreateRepostAsync(int postId, CreateRepostViewModel model);
        List<PostViewModel> GetAll(PostFilter filter);
    }
}
