using Strider.Common;
using Strider.Common.Filters;
using Strider.Domain.Models;

namespace Strider.Domain.Interfaces.Services
{
    public interface IPostService
    {
        Task<Result<PostModel>> CreatePostAsync(PostModel post);
        List<PostModel> GetAll(PostFilter filter);
    }
}
