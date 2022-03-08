namespace Strider.Domain.Models
{
    public class UserModel : BaseModel
    {
        public string UserName { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }
        public List<UserFollowModel>? Followers { get; set; }
        public List<UserFollowModel>? Following { get; set; }
        public List<PostModel>? Posts { get; set; }
    }
}
