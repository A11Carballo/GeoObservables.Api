using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OriginController : Controller
    {
        private readonly ILogger<OriginController> _logger;

        private readonly IOriginServices _originServices;

        public OriginController(ILogger<OriginController> logger, IOriginServices originServices)
        {
            _logger = logger;
            _originServices = originServices;
        }

        //CRUD

        /// <summary>
        /// GET Origin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(OriginViewModel))]
        [HttpGet("{id}")]
        public async Task<OriginViewModel> Get(int id) =>
             OriginMapper.Map(await _originServices.GetOrigin(id));

        /// <summary>
        /// POST Origin
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(OriginViewModel))]
        [HttpPost]
        public async Task<OriginViewModel> AddOrigin([FromBody] OriginViewModel origin) =>
            OriginMapper.Map(await _originServices.AddOrigin(OriginMapper.Map(origin)));

        /// <summary>
        /// Delete Origin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteRol(int id) => await _originServices.DeleteOrigin(id);

        /// <summary>
        /// PUT Origin
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(OriginViewModel))]
        [HttpPut]
        public async Task<OriginViewModel> UpdateOrigin([FromBody] OriginViewModel origin) =>
            OriginMapper.Map(await _originServices.UpdateOrigin(OriginMapper.Map(origin)));


        /// <summary>
        /// GET All Origin
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(List<OriginViewModel>))]
        [HttpGet]
        public async Task<IActionResult> GetAlRoless() =>
             Ok(await _originServices.GetAllOrigins());
    }

}
