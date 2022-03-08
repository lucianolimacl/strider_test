using AutoMapper;
using Strider.Application.Interfaces;
using Strider.Application.ViewModels;
using Strider.Common;
using Strider.Common.Filters;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Models;
using Strider.Domain.Models.Enums;
using System.Transactions;

namespace Strider.Application.AppServices
{
    public class PostAppService : IPostAppService
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostAppService(
            IPostService postService,
            IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public List<PostViewModel> GetAll(PostFilter filter)
        {
            filter.IncludeQuotePost = filter.IncludeQuotePost ?? true;
            filter.IncludeRepost = filter.IncludeRepost ?? true;

            var result = _postService.GetAll(filter);
            return _mapper.Map<List<PostViewModel>>(result);
        }

        public async Task<Result<PostViewModel>> CreatePostAsync(CreatePostViewModel model)
        {
            var mapModel = _mapper.Map<PostModel>(model);

            mapModel.PostType = PostType.Post;

            using (var tran = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _postService.CreatePostAsync(mapModel);
                var mapResult = _mapper.Map<Result<PostViewModel>>(result);

                if (result.Success)
                {
                    tran.Complete();
                }

                return mapResult;
            }
        }

        public async Task<Result<PostViewModel>> CreateRepostAsync(int postId, CreateRepostViewModel model)
        {
            var mapModel = _mapper.Map<PostModel>(model);

            mapModel.PostType = PostType.Repost;
            mapModel.RepostPostId = postId;

            using (var tran = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _postService.CreatePostAsync(mapModel);
                var mapResult = _mapper.Map<Result<PostViewModel>>(result);

                if (result.Success)
                {
                    tran.Complete();
                }

                return mapResult;
            }
        }
    }
}
