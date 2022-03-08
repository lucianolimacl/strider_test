using Strider.Application.ViewModels;
using Strider.Common;

namespace Strider.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<Result<UserViewModel>> CreateUserAsync(CreateUserViewModel model);
        Task<Result<UserFollowViewModel>> FollowUserAsync(int userId, CreateUserFollowViewModel model);
        UserViewModel? GetUserById(int userId);
        Task<Result<UserFollowViewModel>> UnfollowUserAsync(int userId, int userFollowedId);
    }
}
