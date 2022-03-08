using Strider.Domain.Models;

namespace Strider.Domain.Validations.Rules.User
{
    public class UserNameLengthRule : BaseRule<UserModel>
    {
        protected override void VerifyRule(UserModel model)
        {
            if (model.UserName.Length > 14)
            {
                AddError("username can have a maximum of 14 characters");
            }
        }
    }
}
