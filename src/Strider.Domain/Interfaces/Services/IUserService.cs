using Strider.Common;
using Strider.Domain.Models;

namespace Strider.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public UserModel? GetUserById(int userId, bool? includeFollowing = false);
        Task<Result<UserModel>> CreateUserAsync(UserModel user);
        Task<Result<UserFollowModel>> FollowUserAsync(UserFollowModel userFollow);
        Task<Result<UserFollowModel?>> UnfollowUserAsync(int userId, int userFollowedId);
        int CountUserFollowers(int userId);
        int CountUserFollowing(int userId);
        int TotalUserPostAllTime(int userId);
    }
}
