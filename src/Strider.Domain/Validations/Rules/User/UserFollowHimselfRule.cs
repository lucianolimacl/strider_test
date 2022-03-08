using Strider.Domain.Models;

namespace Strider.Domain.Validations.Rules.User
{
    public class UserFollowHimselfRule : BaseRule<UserFollowModel>
    {
        protected override void VerifyRule(UserFollowModel model)
        {
            if (model.FollowingUserId == model.UserFollowedId)
            {
                AddError("users cannot follow themselves");
            }
        }
    }
}
