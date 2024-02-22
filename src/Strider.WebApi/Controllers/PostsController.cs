using Microsoft.AspNetCore.Mvc;
using Strider.Application.Interfaces;
using Strider.Application.ViewModels;
using Strider.Common.Filters;

namespace Strider.WebApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : BaseController
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
        public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostViewModel model)
        {
            var result = await _postAppService.CreatePostAsync(model);
            return FilterResult(result);
        }

        [HttpPost("{id:int}/repost")]
        public async Task<IActionResult> CreateRespostAsync(int id, [FromBody] CreateRepostViewModel model)
        {
            var result = await _postAppService.CreateRepostAsync(id, model);
            return FilterResult(result);
        }
    }
}
