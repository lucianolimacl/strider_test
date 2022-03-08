using Strider.Domain.Models;
using Strider.Domain.Validations.Rules;
using Strider.Domain.Validations.Rules.User;

namespace Strider.Domain.Validations
{
    public class CreateUserValidator : BaseValidator<UserModel>
    {
        protected override List<BaseRule<UserModel>> GetRules()
        {
            return new List<BaseRule<UserModel>>()
            {
                new UserNameLengthRule(),
                new UserNameAlphanumericRule(),
            };
        }
    } 
}
