using NUnit.Framework;

namespace UserResource.BLL.Tests
{
    [TestFixture]
    public class MappingProfileTests
    {
        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            AutoMapper.Mapper.Initialize(configuration => configuration.AddProfile<MappingProfile>());
        }

        [Test]
        public void ConfirmMappingConfiguration()
        {
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}