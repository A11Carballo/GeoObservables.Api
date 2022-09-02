using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.Aplication.Test.MockRepository;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Moq;

namespace GeoObservables.Api.Aplication.Test
{
    public class Tests
    {
        public static IRolesServices _rolesServices;
        [SetUp]
        public static void Setup()
        {
            
           Mock<IRolesRepository> _rolesrepository = new RolesRepositoryMock()._rolesRepository;
           Mock<IAppConfig> _appConfig = new AppConfigMock()._appConfig;

           _rolesServices = new RolesServices(_rolesrepository.Object, _appConfig.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}