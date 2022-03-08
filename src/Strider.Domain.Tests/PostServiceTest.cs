using Moq;
using NUnit.Framework;
using Strider.Common;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Models;
using Strider.Domain.Models.Enums;
using Strider.Domain.Services;
using System.Threading.Tasks;

namespace Strider.Domain.Tests
{
    public class PostServiceTest
    {
        IPostService? postService;

        [SetUp]
        public void Setup()
        {
            var mockPostRepository = new Mock<IPostRepository>();
            mockPostRepository.Setup(x => x.CreatePostAsync(It.IsAny<PostModel>())).Returns<PostModel>((post) =>
            {
                post.Id = 1;
                return Task.FromResult(post);
            });

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.TotalUserPostToday(It.IsAny<int>())).Returns(() =>
            {
                return 0;
            });

            postService = new PostService(mockPostRepository.Object, mockUserRepository.Object);
        }

        [Test]
        public async Task CreatePost_Valid()
        {
            var post = new PostModel
            {
                PostType = PostType.Post,
                Description = "hello world",
                UserId = 1,
            };

            Result<PostModel>? result = null;

            if (postService != null)
            {
                result = await postService.CreatePostAsync(post);
            }

            Assert.True(result?.Data?.Id > 0);
        }

        [Test]
        public async Task CreatePost_With_Invalid_Description()
        {
            var description = "hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world; hello world;  hello world; hello world; hello world; hello world; hello world; hello world;  hello world; hello world; hello world;  hello world; hello world; hello world; hello wo";

            var post = new PostModel
            {
                PostType = PostType.Post,
                Description = description,
                UserId = 1,
            };

            Result<PostModel>? result = null;

            if (postService != null)
            {
                result = await postService.CreatePostAsync(post);
            }

            Assert.False(result?.Success);
        }


        [Test]
        public async Task CreatePost_With_Valid_RepostId()
        {
            var post = new PostModel
            {
                PostType = PostType.Repost,
                Description = "hello world",
                UserId = 1,
                RepostPostId = 1
            };

            if (postService != null)
            {
                await postService.CreatePostAsync(post);
            }

            var repost = new PostModel
            {
                PostType = PostType.Repost,
                UserId = 1,
                RepostPostId = 1
            };

            Result<PostModel>? result = null;

            if (postService != null)
            {
                result = await postService.CreatePostAsync(repost);
            }

            Assert.True(result?.Success);
        }

        [Test]
        public async Task CreatePost_With_Invalid_RepostId()
        {
            var repost = new PostModel
            {
                PostType = PostType.Repost,
                UserId = 1,
                RepostPostId = 0
            };

            Result<PostModel>? result = null;

            if (postService != null)
            {
                result = await postService.CreatePostAsync(repost);
            }

            Assert.False(result?.Success);
        }

    }
}
