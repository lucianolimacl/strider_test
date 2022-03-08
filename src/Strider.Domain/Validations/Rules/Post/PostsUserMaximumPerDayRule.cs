using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Models;

namespace Strider.Domain.Validations.Rules.Post
{
    public class PostsUserMaximumPerDayRule : BaseRule<PostModel>
    {
        private readonly IUserRepository _userRepository;

        public PostsUserMaximumPerDayRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void VerifyRule(PostModel model)
        {
            var totalUserPostToday = _userRepository.TotalUserPostToday(model.UserId);

            if (totalUserPostToday > 5)
            {
                AddError("user is not allowed to post more than 5 posts per day");
            }
        }
    }
}
