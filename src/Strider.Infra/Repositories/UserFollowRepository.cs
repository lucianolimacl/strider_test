using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Models;

namespace Strider.Infra.Repositories
{
    public class UserFollowRepository : BaseRepository, IUserFollowRepository
    {
        public UserFollowRepository(StriderDbContext striderDbContext) : base(striderDbContext)
        {
        }

        public async Task<UserFollowModel> CreateUserFollowAsync(UserFollowModel userFollow)
        {
            _striderDbContext.Add(userFollow);
            await _striderDbContext.SaveChangesAsync();
            return userFollow;
        }

        public UserFollowModel? GetByUserId(int userId, int userFollowedId)
        {
            return _striderDbContext.UserFollows?.Where(x => x.FollowingUserId == userId && x.UserFollowedId == userFollowedId).FirstOrDefault();
        }

        public async Task RemoveAsync(UserFollowModel userFollow)
        {
            _striderDbContext.Remove(userFollow);
            await _striderDbContext.SaveChangesAsync();
        }
    }
}
