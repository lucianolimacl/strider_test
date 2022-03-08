namespace Strider.Common
{
    public class Result<TModel>
    {
        public TModel? Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    
}
