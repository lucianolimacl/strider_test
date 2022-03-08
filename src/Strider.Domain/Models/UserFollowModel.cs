namespace Strider.Domain.Models
{
    public class UserFollowModel : BaseModel
    {
        public int UserFollowedId { get; set; }
        public UserModel? UserFollowed { get; set; }

        public int FollowingUserId { get; set; }
        public UserModel? FollowingUser { get; set; }
    }
}
