using Microsoft.EntityFrameworkCore;
using Strider.Common.Filters;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Models;

namespace Strider.Infra.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(StriderDbContext striderDbContext) : base(striderDbContext)
        {
        }

        public async Task<PostModel> CreatePostAsync(PostModel post)
        {
            _striderDbContext.Add(post);
            await _striderDbContext.SaveChangesAsync();
            return post;
        }

        public PostModel? GetById(int postId)
        {
            return _striderDbContext.Posts?.Where(x => x.Id == postId).FirstOrDefault();
        }

        public List<PostModel> GetAll(PostFilter filter, int[] usersId)
        {
            var query = _striderDbContext.Posts?.AsQueryable();

            if (filter.IncludeOnlyFollowing.HasValue && filter.IncludeOnlyFollowing.Value)
            {
                query = query?.Where(x => usersId.Any(s => s == x.UserId));
            }

            if (filter.IncludeOnlyUserPosts.HasValue && filter.IncludeOnlyUserPosts.Value)
            {
                query = query?.Where(x => x.UserId == filter.UserId);
            }

            if (filter.IncludeQuotePost.HasValue && filter.IncludeQuotePost.Value)
            {
                query = query?.Include(x => x.QuotePost);
            }

            if (filter.IncludeRepost.HasValue && filter.IncludeRepost.Value)
            {
                query = query?.Include(x => x.Repost);
            }

            query = query?.OrderByDescending(x => x.DateCreated);

            return GetPaged(filter, query);
        }
    }
}
