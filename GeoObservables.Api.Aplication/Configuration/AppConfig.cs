using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using Microsoft.Extensions.Configuration;

namespace GeoObservables.Api.Aplication.Configuration
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuaration;

        public AppConfig(IConfiguration configuaration)
        {
            _configuaration = configuaration;
        }

        //Accedemos al appSettings configuración del Polly.                            
        public int MaxTrys()
        {
            if (!string.IsNullOrEmpty(_configuaration.GetSection("Polly:MaxTrys").Value))
            {
                return (int.Parse(_configuaration.GetSection("Polly:MaxTrys").Value));
            }
            //Valor por defecto, si no viene informado devolveremos 5.
            return 5;
        }


        public int SecondsToWait()
        {
            if (!string.IsNullOrEmpty(_configuaration.GetSection("Polly:TimeDelay").Value))
            {
                return (int.Parse(_configuaration.GetSection("Polly:TimeDelay").Value));
            }
            //Valor por defecto, si no viene informado devolveremos 5.
            return 2;
        }

        public string ServiceUrl => _configuaration.GetSection("ServiceUrl:Url").Value;

        public string JwtSubject => _configuaration.GetSection("Jwt:Subject").Value;
        public string JwtKey => _configuaration.GetSection("Jwt:Key").Value;
        public string JwtAudience => _configuaration.GetSection("Jwt:Audience").Value;
        public string JwtIssuer => _configuaration.GetSection("Jwt:Issuer").Value;
        public string ExpireToken => _configuaration.GetSection("AppSettings:ExpireToken").Value;

    }
}
