using System.Linq;
using AutoMapper;
using ExternalSynchronization;
using Moq;
using NUnit.Framework;
using UserResource.DAL;
using UserResource.DAL.Entities;

namespace UserResource.BLL.Tests
{
    [TestFixture]
    public class UserBLLTests
    {
        private UserBLL _sut;
        private Mock<IMapper> _mapper;
        private Mock<IExternalUserClient> _externalUserClient;
        private Mock<IUserDAL> _userDal;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _userDal = new Mock<IUserDAL>(MockBehavior.Strict);
            _externalUserClient = new Mock<IExternalUserClient>(MockBehavior.Strict);

            _sut = new UserBLL(_userDal.Object, _externalUserClient.Object, _mapper.Object);
        }

        [Test]
        public void CreatingANewUserReturnsBackThatUser()
        {
            _userDal.Setup(x => x.Create(It.IsAny<User>()))
                .Returns(Mother.UserOleg);
            _externalUserClient.Setup(x => x.Save(It.IsAny<ExternalUser>()))
                .Returns(new ExternalUser());
            //Setup for _mapper.

            var expected = Mother.UserOleg.Id;
            var actual = _sut.CreateUser(Mother.UserOleg).Id;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGetAListOfUsersThatAreAllActive()
        {
            _userDal.Setup(x => x.Get(It.IsAny<Paging>(), It.IsAny<FilterCriteria>()))
                .Returns(Mother.Users);

            var actual = _sut.GetUsers(Mother.Paging);

            Assert.That(actual.Count(), Is.GreaterThan(0));
        }
    }
}