using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Test.Stubs;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Moq;

namespace GeoObservables.Api.Aplication.Test.MockRepository
{
    public class AppConfigMock
    {
        public Mock<IAppConfig> _appConfig { get; set; }
        public AppConfigMock()
        {
            _appConfig = new Mock<IAppConfig>();
        }

        [SetUp]
        public void Setup()
        {

        }
    }
}
