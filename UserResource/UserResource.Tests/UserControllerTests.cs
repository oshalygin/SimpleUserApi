using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using UserResource.BLL;
using UserResource.Controllers;
using UserResource.DAL;
using UserResource.DAL.Entities;
using UserResource.Models;

namespace UserResource.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _sut;
        private Mock<IMapper> _mapper;
        private Mock<IUserBLL> _userBll;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _userBll = new Mock<IUserBLL>(MockBehavior.Strict);

            _sut = new UserController(_mapper.Object, _userBll.Object);

        }

        [Test]
        public void CallingTheBaseEndpointReturnsAListOfUsers()
        {
            _mapper.Setup(
                x => x.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(It.IsAny<IEnumerable<User>>()))
                .Returns(Mother.UsersViewModel);
            _userBll.Setup(x => x.GetUsers(It.IsAny<Paging>()))
                .Returns(Mother.Users);

            var usersResponse = _sut.GetUsers(Mother.Page, Mother.PageSize) as
                    OkNegotiatedContentResult<IEnumerable<UserViewModel>>;

            var users = usersResponse?.Content;
            Assert.That(users?.Count(), Is.GreaterThan(0));

        }

      // ...More tests to follow for each endpoint
    }
}