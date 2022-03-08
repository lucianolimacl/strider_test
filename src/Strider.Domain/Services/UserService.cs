using Strider.Common;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Models;
using Strider.Domain.Validations;

namespace Strider.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFollowRepository _userFollowRepository;

        public UserService(
            IUserRepository userRepository,
            IUserFollowRepository userFollowRepository)
        {
            _userRepository = userRepository;
            _userFollowRepository = userFollowRepository;
        }

        public UserModel? GetUserById(int userId, bool? includeFollowing = false)
        {
            return _userRepository.GetById(userId, includeFollowing);
        }

        public int TotalUserPostAllTime(int userId)
        {
            return _userRepository.TotalUserPostAllTime(userId);
        } 
        
        public int CountUserFollowers(int userId)
        {
            return _userRepository.CountUserFollowers(userId);
        }
       
        public int CountUserFollowing(int userId)
        {
            return _userRepository.CountUserFollowing(userId);
        }

        public async Task<Result<UserModel>> CreateUserAsync(UserModel user)
        {
            var validation = new CreateUserValidator().Validate(user);

            if (!validation.Success)
            {
                return validation;
            }

            user.DateJoined = DateTime.UtcNow;

            user = await _userRepository.CreateUserAsync(user);

            return Result.Succeed(user);
        }

        public async Task<Result<UserFollowModel>> FollowUserAsync(UserFollowModel userFollow)
        {
            var validation = new CreateUserFollowValidator().Validate(userFollow);

            if (!validation.Success)
            {
                return validation;
            }

            userFollow = await _userFollowRepository.CreateUserFollowAsync(userFollow);

            return Result.Succeed(userFollow);
        }

        public async Task<Result<UserFollowModel?>> UnfollowUserAsync(int userId, int userFollowedId)
        {
            var userFollow = _userFollowRepository.GetByUserId(userId, userFollowedId);

            if (userFollow != null)
            {
                await _userFollowRepository.RemoveAsync(userFollow);
            }

            return Result.Succeed(userFollow);
        }
    }
}
