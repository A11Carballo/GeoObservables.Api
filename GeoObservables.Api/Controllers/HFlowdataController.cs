using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.HFlowCommands;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HFlowdataController : Controller
    {
        private readonly IMediator _mediator;

        public HFlowdataController(IMediator mediator)
        {
            _mediator = mediator;
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
            await _mediator.Send(new GetHFlowdataQuery { IdHFlow = idHFlow });

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
        public async Task<HFlowdataViewModel> AddHFlow([FromBody] HFlowdataViewModel HFlow) =>
            await _mediator.Send(new CreateHFlowdataCommand { HFlowdata = HFlow});

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
        public async Task<bool> DeleteHFlow(int idHFlow) =>
                    await _mediator.Send(new DeleteHFlowdataCommand { IdHFlow = idHFlow });

        /// <summary>
        /// PUT HFlow
        /// </summary>
        /// <param name="HFlow"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HFlowdataViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(HFlowdataViewModel))]
        [HttpPut]
        public async Task<HFlowdataViewModel> UpdateHFlow([FromBody] HFlowdataViewModel HFlow) =>
                   await _mediator.Send(new UpdateHFlowdataCommand { HFlowdata = HFlow });

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
        public async Task<IActionResult> GetAlHFlows() => 
            Ok(await _mediator.Send(new GetAllHFlowdataQuery()));
    }

}
