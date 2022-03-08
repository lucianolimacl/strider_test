namespace Strider.Common.Filters
{
    public abstract class BaseFilter
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }

    public class PostFilter : BaseFilter
    {
        public int UserId { get; set; }
        public bool? IncludeOnlyFollowing { get; set; }
        public bool? IncludeOnlyUserPosts { get; set; }
        public bool? IncludeQuotePost { get; set; }
        public bool? IncludeRepost { get; set; }
    }
}
