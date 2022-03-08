using Strider.Common.Filters;

namespace Strider.Infra.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly StriderDbContext _striderDbContext;
        public BaseRepository(StriderDbContext striderDbContext)
        {
            _striderDbContext = striderDbContext;
        }

        protected List<TModel> GetPaged<TModel>(BaseFilter filter, IQueryable<TModel>? query)
        {
            if (filter.PageSize <= 0)
            {
                filter.PageSize = 10;
            }
            
            if (filter.Page <= 0)
            {
                filter.Page = 1;
            }

            var skip = (filter.Page - 1) * filter.PageSize;
            var result = query?.Skip(skip).Take(filter.PageSize).ToList();
            result = result ?? new List<TModel>();
            return result;
        }
    }
}
