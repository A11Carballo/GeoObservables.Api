using GeoObservables.Api.Aplication.Contracts.ApiCaller;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiCallerController : Controller
    {
        private readonly Lazy<ILogger<HFlowdataController>> _logger;

        private readonly Lazy<IHFlowdataServices> _hFlowdataServices;

        private readonly Lazy<IApiCaller> _apiCaller; 

        public ApiCallerController(Lazy<ILogger<HFlowdataController>> logger, Lazy<IHFlowdataServices> hFlowdataServices, Lazy<IApiCaller> apiCaller)
        {
            _logger = logger;
            _hFlowdataServices = hFlowdataServices;
            _apiCaller= apiCaller;
        }

        //CRUD

        /// <summary>
        /// GET HFlow from Other API
        /// </summary>
        /// <param name="idHFlow"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(HFlowdataViewModel))]
        [HttpGet("{idHFlow}")]
        public async Task<HFlowdataViewModel> Get(int idHFlow) =>
             HFlowdataMapper.Map(await _apiCaller.Value.GetServiceResponseById<HFlowdataModel>("HFlowdataController", idHFlow));

    }

}
