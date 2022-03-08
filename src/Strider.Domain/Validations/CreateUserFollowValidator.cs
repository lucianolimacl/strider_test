using Strider.Domain.Models;
using Strider.Domain.Validations.Rules;
using Strider.Domain.Validations.Rules.User;

namespace Strider.Domain.Validations
{
    public class CreateUserFollowValidator : BaseValidator<UserFollowModel>
    {
        protected override List<BaseRule<UserFollowModel>> GetRules()
        {
            return new List<BaseRule<UserFollowModel>>()
            {
                new UserFollowHimselfRule(),
            };
        }
    }
}
