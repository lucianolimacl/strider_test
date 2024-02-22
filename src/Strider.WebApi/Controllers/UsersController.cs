using Microsoft.AspNetCore.Mvc;
using Strider.Application.Interfaces;
using Strider.Application.ViewModels;
using Strider.Common.Filters;

namespace Strider.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
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
        public async Task<IActionResult> CreateUserAsync(CreateUserViewModel model)
        {
            var result = await _userAppService.CreateUserAsync(model);
            return FilterResult(result);
        }

        [HttpPost("{id:int}/follow")]
        public async Task<IActionResult> FollowUserAsync(int id, CreateUserFollowViewModel model)
        {
            var result = await _userAppService.FollowUserAsync(id, model);
            return FilterResult(result);
        }

        [HttpPost("{id:int}/unfollow/{userFollowedId:int}")]
        public async Task<IActionResult> UnfollowUserAsync(int id, int userFollowedId)
        {
            var result = await _userAppService.UnfollowUserAsync(id, userFollowedId);
            return FilterResult(result);
        }
    }
}
