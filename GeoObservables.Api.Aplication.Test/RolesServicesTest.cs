using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.Aplication.Test.MockRepository;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit.Sdk;
using TestContext = NUnit.Framework.TestContext;

namespace GeoObservables.Api.Aplication.Test
{
    public class RolesServicesTest
    {
        public static IRolesServices _rolesServices;


        [SetUp]
        public static void Setup(TestContext context) 
        {
            Mock<IRolesRepository> _rolesrepository = new RolesRepositoryMock()._rolesRepository;
            Mock<IAppConfig> _appConfig = new AppConfigMock()._appConfig;

            _rolesServices = new RolesServices(_rolesrepository.Object, _appConfig.Object);
        }

        [Test]
        public async Task LlamandoGetRoldadoUnIdDevuelveUnRol()
        {
            //Preparación

            //Ejecución
            var result = await _rolesServices.GetRol(1);

            //Aserción
            result.Role.Should().NotBeNullOrEmpty();
            result.Id.Should().NotBe(2);

        }

        [Test]
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
