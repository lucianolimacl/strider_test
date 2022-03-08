namespace Strider.Application.ViewModels
{
    public class CreatePostViewModel
    {
        public int UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? QuotePostId { get; set; }
    }
}
