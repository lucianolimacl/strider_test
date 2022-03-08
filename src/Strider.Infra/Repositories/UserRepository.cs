using Microsoft.EntityFrameworkCore;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Models;

namespace Strider.Infra.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(StriderDbContext striderDbContext) : base(striderDbContext)
        {
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _striderDbContext.Add(user);
            await _striderDbContext.SaveChangesAsync();
            return user;
        }

        public UserModel? GetById(int userId, bool? includeFollowing = false)
        {
            var query = _striderDbContext.Users?.Where(x => x.Id == userId);
            if (includeFollowing.HasValue && includeFollowing.Value)
            {
                query = query?.Include(x => x.Following);
            }

            return query?.FirstOrDefault();
        }

        public int TotalUserPostToday(int userId)
        {
            var total = _striderDbContext.Posts?.Where(x => x.UserId == userId && x.DateCreated.Date == DateTime.UtcNow.Date).Count();
            total = total ?? 0;
            return total.Value;
        }

        public int TotalUserPostAllTime(int userId)
        {
            var total = _striderDbContext.Posts?.Where(x => x.UserId == userId).Count();
            total = total ?? 0;
            return total.Value;
        }

        public int CountUserFollowers(int userId)
        {
            var total = _striderDbContext.UserFollows?.Where(x => x.UserFollowedId == userId).Count();
            total = total ?? 0;
            return total.Value;
        }

        public int CountUserFollowing(int userId)
        {
            var total = _striderDbContext.UserFollows?.Where(x => x.FollowingUserId == userId).Count();
            total = total ?? 0;
            return total.Value;
        }
    }
}
