using Strider.Common;
using Strider.Domain.Validations.Rules;

namespace Strider.Domain.Validations
{
    public abstract class BaseValidator<TModel>
    {
        public Result<TModel> Validate(TModel model)
        {
            var rules = this.GetRules();

            var result = new List<string>();

            foreach (var rule in rules)
            {
                var errors = rule.Validate(model);
                result.AddRange(errors);
            }

            if (result.Count > 0)
            {
                return Result.Failed<TModel>(result);
            }
            else
            {
                return new Result<TModel> { Success = true };
            }
        }

        protected abstract List<BaseRule<TModel>> GetRules();
    }
}
