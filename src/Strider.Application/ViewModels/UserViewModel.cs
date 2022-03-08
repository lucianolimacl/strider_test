namespace Strider.Application.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string? UserName { get; set; }
        public string? DateJoined { get; set; }
        public int NumberFollowers { get; set; }
        public int NumberFollowing { get; set; }
        public int CountPosts { get; set; }
    }
}
