using AutoMapper;
using Strider.Application.Interfaces;
using Strider.Application.ViewModels;
using Strider.Common;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Models;
using System.Transactions;

namespace Strider.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserAppService(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public UserViewModel? GetUserById(int userId)
        {
            var result = _userService.GetUserById(userId);
            var map = _mapper.Map<UserViewModel>(result);
            map.NumberFollowing = _userService.CountUserFollowing(userId);
            map.NumberFollowers = _userService.CountUserFollowers(userId);
            map.CountPosts = _userService.TotalUserPostAllTime(userId);
            
            return map;
        }

        public async Task<Result<UserViewModel>> CreateUserAsync(CreateUserViewModel model)
        {
            var mapModel = _mapper.Map<UserModel>(model);
            using (var tran = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _userService.CreateUserAsync(mapModel);
                var mapResult = _mapper.Map<Result<UserViewModel>>(result);

                if (result.Success)
                {
                    tran.Complete();
                }

                return mapResult;
            }
        }

        public async Task<Result<UserFollowViewModel>> FollowUserAsync(int userId, CreateUserFollowViewModel model)
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _userService.FollowUserAsync(new UserFollowModel
                {
                    FollowingUserId = userId,
                    UserFollowedId = model.UserFollowedId
                });

                var mapResult = _mapper.Map<Result<UserFollowViewModel>>(result);

                if (result.Success)
                {
                    tran.Complete();
                }

                return mapResult;
            }
        }

        public async Task<Result<UserFollowViewModel>> UnfollowUserAsync(int userId, int userFollowedId)
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _userService.UnfollowUserAsync(userId, userFollowedId);

                var mapResult = _mapper.Map<Result<UserFollowViewModel>>(result);

                if (result.Success)
                {
                    tran.Complete();
                }

                return mapResult;
            }
        }
    }
}
