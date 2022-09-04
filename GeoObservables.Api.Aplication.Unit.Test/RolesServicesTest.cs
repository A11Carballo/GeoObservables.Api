

using FluentAssertions;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.Aplication.Unit.Test.MockRepository;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Moq;

namespace GeoObservables.Api.Aplication.Test
{
    [TestClass]
    public class RolesServicesTest
    {
        public static IRolesServices _rolesServices;


        [ClassInitialize()]
        public static void Setup(TestContext context) 
        {
            Mock<IRolesRepository> _rolesrepository = new RolesRepositoryMock()._rolesRepository;
            Mock<IAppConfig> _appConfig = new AppConfigMock()._appConfig;

            _rolesServices = new RolesServices(_rolesrepository.Object, _appConfig.Object);
        }

        [TestMethod]
        public async Task LlamandoGetRoldadoUnIdDevuelveUnRol()
        {
            //Preparación

            //Ejecución
            var result = await _rolesServices.GetRolRequest(1);

            //Aserción
            result.Role.Should().NotBeNullOrEmpty();
            result.Id.Should().NotBe(2);

        }

        [TestMethod]
        public async Task LlamandoGetAllDevuelveTodosRoles()
        {
            //Preparación

            //Ejecución
            var result = await _rolesServices.GetAllRoles();

            //Aserción
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(1);

        }
    }
}
