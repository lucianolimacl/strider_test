using Moq;
using NUnit.Framework;
using Strider.Common;
using Strider.Domain.Interfaces.Repositories;
using Strider.Domain.Interfaces.Services;
using Strider.Domain.Models;
using Strider.Domain.Services;
using System.Threading.Tasks;

namespace Strider.Domain.Tests
{
    public class UserServiceTest
    {
        IUserService? userService;

        [SetUp]
        public void Setup()
        {
            int userId = 1;
            int userFollowId = 1;

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.CreateUserAsync(It.IsAny<UserModel>())).Returns<UserModel>((user) =>
            {
                user.Id = userId++;
                return Task.FromResult(user);
            });

            var mockUserFollowRepository = new Mock<IUserFollowRepository>();
            mockUserFollowRepository.Setup(x => x.CreateUserFollowAsync(It.IsAny<UserFollowModel>())).Returns<UserFollowModel>((userFollow) =>
            {
                userFollow.Id = userFollowId++;
                return Task.FromResult(userFollow);
            });

            userService = new UserService(mockUserRepository.Object, mockUserFollowRepository.Object);
        }

        [Test]
        public async Task CreateUser_Valid()
        {
            var user = new UserModel
            {
                Id = 0,
                UserName = "user1"
            };

            Result<UserModel>? result = null;

            if (userService != null)
            {
                result = await userService.CreateUserAsync(user);
            }

            Assert.True(result?.Data?.Id > 0);
        }

        [Test]
        public async Task CreateUser_With_Invalid_Name()
        {
            var name = "user@1";

            var user = new UserModel
            {
                Id = 0,
                UserName = name
            };

            Result<UserModel>? result = null;

            if (userService != null)
            {
                result = await userService.CreateUserAsync(user);
            }

            Assert.False(result?.Success);
        }

        [Test]
        public async Task FollowUser_With_Valid_Follower()
        {
            var user1 = new UserModel
            {
                Id = 0,
                UserName = "user1"
            };

            var user2 = new UserModel
            {
                Id = 0,
                UserName = "user2"
            };

            if (userService != null)
            {
                await userService.CreateUserAsync(user1);
                await userService.CreateUserAsync(user2);
            }

            Result<UserFollowModel>? result = null;

            if (userService != null)
            {
                result = await userService.FollowUserAsync(new UserFollowModel
                {
                    UserFollowedId = user1.Id,
                    FollowingUserId = user2.Id
                });
            }

            Assert.True(result?.Success);
        }

        [Test]
        public async Task FollowUser_With_Invalid_Follower()
        {
            var name = "user1";

            var user = new UserModel
            {
                Id = 0,
                UserName = name
            };

            Result<UserFollowModel>? result = null;

            if (userService != null)
            {
                await userService.CreateUserAsync(user);
            }

            if (userService != null)
            {
                result = await userService.FollowUserAsync(new UserFollowModel
                {
                    UserFollowedId = user.Id,
                    FollowingUserId = user.Id
                });
            }

            Assert.False(result?.Success);
        }
    }
}
