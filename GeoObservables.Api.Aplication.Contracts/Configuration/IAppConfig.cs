using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Aplication.Contracts.Configuration
{
    public interface IAppConfig
    {
        public int MaxTrys();
        public int SecondsToWait();
        public string ServiceUrl { get; }
        public string JwtSubject { get; }

        public string JwtAudience { get; }

        public string JwtKey { get; }

        public string JwtIssuer { get; }

        public string ExpireToken { get; }
    }
}
