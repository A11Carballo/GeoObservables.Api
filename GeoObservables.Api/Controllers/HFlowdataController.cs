using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HFlowdataController : Controller
    {
        private readonly Lazy<ILogger<HFlowdataController>> _logger;

        private readonly Lazy<IHFlowdataServices> _hFlowdataServices;

        public HFlowdataController(Lazy<ILogger<HFlowdataController>> logger, Lazy<IHFlowdataServices> hFlowdataServices)
        {
            _logger = logger;
            _hFlowdataServices = hFlowdataServices;
        }

        //CRUD

        /// <summary>
        /// GET HFlow
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
             HFlowdataMapper.Map(await _hFlowdataServices.Value.GetHFlowdata(idHFlow));

        /// <summary>
        /// POST HFlow
        /// </summary>
        /// <param name="HFlow"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(HFlowdataViewModel))]
        [HttpPost]
        public async Task<HFlowdataViewModel> AddRol([FromBody] HFlowdataViewModel HFlow) =>
            HFlowdataMapper.Map(await _hFlowdataServices.Value.AddHFlowdata(HFlowdataMapper.Map(HFlow)));

        /// <summary>
        /// Delete HFlow
        /// </summary>
        /// <param name="idHFlow"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{idHFlow}")]
        public async Task<bool> DeleteRol(int idHFlow) => await _hFlowdataServices.Value.DeleteHFlowdata(idHFlow);

        /// <summary>
        /// PUT HFlow
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(HFlowdataViewModel))]
        [HttpPut]
        public async Task<HFlowdataViewModel> UpdateRoles([FromBody] HFlowdataViewModel HFlow) =>
            HFlowdataMapper.Map(await _hFlowdataServices.Value.UpdateHFlowdata(HFlowdataMapper.Map(HFlow)));


        /// <summary>
        /// GET All HFlows
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(List<HFlowdataViewModel>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HFlowdataViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<HFlowdataViewModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<HFlowdataViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<HFlowdataViewModel>))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(List<HFlowdataViewModel>))]
        [HttpGet]
        public async Task<IActionResult> GetAlRoless() =>
             Ok(await _hFlowdataServices.Value.GetAllHFlows());
    }

}
