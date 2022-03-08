using Strider.Common;
using Strider.Common.Filters;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Models;
using Strider.Domain.Models.Enums;
using Strider.Domain.Validations;

namespace Strider.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userProfileRepository;

        public PostService(IPostRepository postRepository, IUserRepository userProfileRepository)
        {
            _postRepository = postRepository;
            _userProfileRepository = userProfileRepository;
        }

        public List<PostModel> GetAll(PostFilter filter)
        {
            var user = _userProfileRepository.GetById(filter.UserId, true);

            List<int> usersId = new List<int>();

            if (filter.IncludeOnlyFollowing.HasValue && filter.IncludeOnlyFollowing.Value)
            {
                var followingUserIds = user?.Following?.Select(x => x.UserFollowedId).ToList();
                if (followingUserIds != null)
                {
                    usersId.AddRange(followingUserIds);
                }
            }

            return _postRepository.GetAll(filter, usersId.ToArray());
        }

        public async Task<Result<PostModel>> CreatePostAsync(PostModel post)
        {
            var validation = new CreatePostValidator(_userProfileRepository).Validate(post);

            if (!validation.Success)
            {
                return validation;
            }

            post.DateCreated = DateTime.UtcNow;

            post = await _postRepository.CreatePostAsync(post);

            if (post.PostType == PostType.Post && post.QuotePostId.HasValue && post.QuotePostId.Value > 0)
            {
                post.QuotePost = _postRepository.GetById(post.QuotePostId.Value);
            }

            if (post.PostType == PostType.Repost && post.RepostPostId.HasValue && post.RepostPostId.Value > 0)
            {
                post.Repost = _postRepository.GetById(post.RepostPostId.Value);
            }


            return Result.Succeed(post);
        }
    }
}
