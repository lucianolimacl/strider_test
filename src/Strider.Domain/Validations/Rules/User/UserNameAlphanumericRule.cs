using Strider.Domain.Models;
using System.Text.RegularExpressions;

namespace Strider.Domain.Validations.Rules.User
{
    public class UserNameAlphanumericRule : BaseRule<UserModel>
    {
        protected override void VerifyRule(UserModel model)
        {
            if (!Regex.IsMatch(model.UserName, "^[a-zA-Z0-9]*$"))
            {
                AddError("only alphanumeric characters can be used for username");
            }
        }
    }
}
