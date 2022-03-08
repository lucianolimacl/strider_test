namespace Strider.Common
{
    public static class Result
    {
        public static Result<TModel> Succeed<TModel>(TModel data)
        {
            return new Result<TModel>
            {
                Success = true,
                Data = data
            };
        } 
        
        public static Result<TModel> Failed<TModel>(List<string> errors)
        {
            return new Result<TModel>
            {
                Success = false,
                Errors = errors
            };
        }
    }
}
