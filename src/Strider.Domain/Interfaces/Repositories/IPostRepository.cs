using Strider.Common.Filters;
using Strider.Domain.Models;

namespace Strider.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        List<PostModel> GetAll(PostFilter filter, int[] usersId);
        Task<PostModel> CreatePostAsync(PostModel post);
        PostModel? GetById(int postId);
    }
}
