using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Models;
using Strider.Domain.Validations.Rules;
using Strider.Domain.Validations.Rules.Post;

namespace Strider.Domain.Validations
{
    public class CreatePostValidator : BaseValidator<PostModel>
    {
        private readonly IUserRepository _userRepository;

        public CreatePostValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override List<BaseRule<PostModel>> GetRules()
        {
            return new List<BaseRule<PostModel>>()
            {
                new PostDescriptionLengthRule(),
                new PostsUserMaximumPerDayRule(_userRepository),
                new PostRepostRule(),
            };
        }
    }
}
