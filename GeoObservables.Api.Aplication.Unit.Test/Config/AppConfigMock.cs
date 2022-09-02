

using GeoObservables.Api.Aplication.Contracts.Configuration;
using Moq;
using NUnit.Framework;

namespace GeoObservables.Api.Aplication.Unit.Test.MockRepository
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
