using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Aplication.Contracts.Models
{
    public class TokenResource
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }
}
