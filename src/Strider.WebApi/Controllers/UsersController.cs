using Microsoft.AspNetCore.Mvc;
using Strider.Application.Interfaces;
using Strider.Application.ViewModels;
using Strider.Common;
using Strider.Common.Filters;

namespace Strider.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IPostAppService _postAppService;

        public UsersController(IUserAppService userAppService, IPostAppService postAppService)
        {
            _userAppService = userAppService;
            _postAppService = postAppService;
        }

        [HttpGet("{id:int}")]
        public UserViewModel? GetUserById(int id)
        {
            return _userAppService.GetUserById(id);
        }

        [HttpGet("{id:int}/posts")]
        public List<PostViewModel>? GetPostsUser(int id)
        {
            return _postAppService.GetAll(new PostFilter
            {
                UserId = id,
                PageSize = 5,
                IncludeOnlyUserPosts = true
            });
        }

        [HttpPost]
        public async Task<Result<UserViewModel>> CreateUserAsync(CreateUserViewModel model)
        {
            return await _userAppService.CreateUserAsync(model);
        }

        [HttpPost("{id:int}/follow")]
        public async Task<Result<UserFollowViewModel>> FollowUserAsync(int id, CreateUserFollowViewModel model)
        {
            return await _userAppService.FollowUserAsync(id, model);
        }

        [HttpPost("{id:int}/unfollow/{userFollowedId:int}")]
        public async Task<Result<UserFollowViewModel>> UnfollowUserAsync(int id, int userFollowedId)
        {
            return await _userAppService.UnfollowUserAsync(id, userFollowedId);
        }
    }
}
