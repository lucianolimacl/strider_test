using Strider.Domain.Models;

namespace Strider.Domain.Validations.Rules.Post
{
    public class PostRepostRule : BaseRule<PostModel>
    {
        protected override void VerifyRule(PostModel model)
        {
            if (model.PostType == Models.Enums.PostType.Repost)
            {
                if (!model.RepostPostId.HasValue || model.RepostPostId.Value <= 0)
                {
                    AddError($"required field {nameof(model.RepostPostId)}");
                }
            }
        }
    }
}
