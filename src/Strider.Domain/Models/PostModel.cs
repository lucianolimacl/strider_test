using Strider.Domain.Models.Enums;

namespace Strider.Domain.Models
{
    public class PostModel : BaseModel
    {
        public PostType PostType { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } 
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public int? QuotePostId { get; set; }
        public PostModel? QuotePost { get; set; }
        public int? RepostPostId { get; set; }
        public PostModel? Repost { get; set; }
    }
}
