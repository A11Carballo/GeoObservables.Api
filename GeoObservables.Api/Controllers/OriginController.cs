using GeoObservables.Api.Commands.OriginCommands;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OriginController : Controller
    {
        private readonly ILogger<OriginController> _logger;

        private readonly IMediator _mediator;

        public OriginController(ILogger<OriginController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //CRUD

        /// <summary>
        /// GET Origin
        /// </summary>
        /// <param name="idOri"></param>
        /// <returns>OriginViewModel</returns>
        [Produces("application/json", Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(OriginViewModel))]
        [HttpGet("{idOri}")]
        public async Task<OriginViewModel> Get(int idOri) =>
             await _mediator.Send(new GetOriginQuery { IdOrigin = idOri });

        /// <summary>
        /// POST Origin
        /// </summary>
        /// <param name="Origin"></param>
        /// <returns>OriginViewModel</returns>
        [Produces("application/json", Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(OriginViewModel))]
        [HttpPost]
        public async Task<OriginViewModel> AddOrigin([FromBody] OriginViewModel origin) =>
            await _mediator.Send(new CreateOriginCommand { Origin = origin });

        /// <summary>
        /// Delete Origin
        /// </summary>
        /// <param name="idOri"></param>
        /// <returns>bool</returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{idOri}")]
        public async Task<bool> DeleteRol(int idOri) => await _mediator.Send(new DeleteOriginCommand { IdOrigin = idOri });

        /// <summary>
        /// PUT Origin
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>OriginViewModel</returns>
        [Produces("application/json", Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OriginViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(OriginViewModel))]
        [HttpPut]
        public async Task<OriginViewModel> UpdateOrigin([FromBody] OriginViewModel origin) =>
            await _mediator.Send(new UpdateOriginCommand { Origin = origin });


        /// <summary>
        /// GET All Origin
        /// </summary>
        /// <param></param>
        /// <returns>List<OriginViewModel></returns>
        [Produces("application/json", Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<OriginViewModel>))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(List<OriginViewModel>))]
        [HttpGet]
        public async Task<IActionResult> GetAlRoless() => Ok(await _mediator.Send(new GetAllOriginQuery()));

        /// <summary>
        /// Exist Origin
        /// </summary>
        /// <param name="idOri"></param>
        /// <returns>bool</returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpGet("exist/{idOri}")]
        public async Task<bool> ExistRol(int idOri) => await _mediator.Send(new ExistOriginCommand { IdOrigin = idOri });
    }

}
