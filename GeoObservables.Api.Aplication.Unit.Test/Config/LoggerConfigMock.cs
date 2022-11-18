

using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace GeoObservables.Api.Aplication.Unit.Test.MockRepository
{
    public class LoggerMock
    {
        public Mock<ILogger> _logger { get; set; }
        public LoggerMock()
        {
            _logger = new Mock<ILogger>();
        }

        [SetUp]
        public void Setup()
        {

        }
    }
}
