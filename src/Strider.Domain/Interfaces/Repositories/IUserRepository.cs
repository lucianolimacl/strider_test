using Strider.Domain.Models;

namespace Strider.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        UserModel? GetById(int userId, bool? includeFollowing = false);
        Task<UserModel> CreateUserAsync(UserModel user);
        int TotalUserPostAllTime(int userId);
        int TotalUserPostToday(int userId);
        int CountUserFollowers(int userId);
        int CountUserFollowing(int userId);
    }
}
