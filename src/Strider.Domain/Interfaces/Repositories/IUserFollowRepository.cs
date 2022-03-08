using Strider.Domain.Models;

namespace Strider.Domain.Interfaces.Repositories
{
    public interface IUserFollowRepository
    {
        Task<UserFollowModel> CreateUserFollowAsync(UserFollowModel userFollow);
        UserFollowModel? GetByUserId(int userId, int userFollowedId);
        Task RemoveAsync(UserFollowModel userFollow);
    }
}
