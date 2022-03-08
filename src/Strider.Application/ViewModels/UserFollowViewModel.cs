namespace Strider.Application.ViewModels
{
    public class UserFollowViewModel
    {
        public int UserFollowedId { get; set; }
        public UserViewModel? UserFollowed { get; set; }

        public int FollowingUserId { get; set; }
        public UserViewModel? FollowingUser { get; set; }
    }
}
