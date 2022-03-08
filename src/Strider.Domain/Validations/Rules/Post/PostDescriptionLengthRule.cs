using Strider.Domain.Models;

namespace Strider.Domain.Validations.Rules.Post
{
    public class PostDescriptionLengthRule : BaseRule<PostModel>
    {
        protected override void VerifyRule(PostModel model)
        {
            if (model.Description.Length > 777)
            {
                AddError("posts can have a maximum of 777 characters");
            }
        }
    }
}
