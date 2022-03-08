namespace Strider.Application.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? DateCreated { get; set; }
        public PostViewModel? QuotePost { get; set; }
        public PostViewModel? Repost { get; set; }
    }
}
