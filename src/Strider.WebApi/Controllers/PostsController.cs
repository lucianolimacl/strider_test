using Microsoft.AspNetCore.Mvc;
using Strider.Application.Interfaces;
using Strider.Application.ViewModels;
using Strider.Common;
using Strider.Common.Filters;

namespace Strider.WebApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpGet]
        public List<PostViewModel> GetAll([FromQuery] PostFilter filter)
        {
            return _postAppService.GetAll(filter);
        }

        [HttpPost]
        public async Task<Result<PostViewModel>> CreatePostAsync([FromBody] CreatePostViewModel model)
        {
            return await _postAppService.CreatePostAsync(model);
        }

        [HttpPost("{id:int}/repost")]
        public async Task<Result<PostViewModel>> CreateRespostAsync(int id, [FromBody] CreateRepostViewModel model)
        {
            return await _postAppService.CreateRepostAsync(id, model);
        }
    }
}
