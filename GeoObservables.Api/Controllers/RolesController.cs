using GeoObservables.Api.Commands.RolesCommands;
using GeoObservables.Api.Queries;
using GeoObservables.Api.Request;
using GeoObservables.Api.Response.Roles;
using GeoObservables.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //CRUD

        /// <summary>
        /// GET Rol
        /// </summary>
        /// <param id="IdRol"></param
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpGet("{IdRol}")]
        public async Task<RolesViewModel>Get(int IdRol) =>
             await _mediator.Send(new GetRolesQuery { IdRoles = IdRol });


        /// <summary>
        /// POST Rol
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesResponse))]
        [HttpPost]
        public async Task<RolesViewModel> AddRol([FromBody] RolesViewModel rol) =>
            await _mediator.Send(new CreateRolesCommand { Roles = rol });

        /// <summary>
        /// Delete Rol
        /// </summary>
        /// <param name="Rol"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesBoolResponse))]
        [HttpDelete]
        public async Task<bool> DeleteRol([FromBody] RolesViewModel Rol) => await _mediator.Send(new DeleteRolesCommand { IdRoles = Rol.Id });  


        /// <summary>
        /// PUT Rol
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesResponse))]
        [HttpPut]
        public async Task<RolesViewModel> UpdateRoles([FromBody] RolesViewModel rol) =>
                       await _mediator.Send(new UpdateRolesCommand { Roles = rol });

        /// <summary>
        /// GET All Roles
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(List<RolesResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RolesResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<RolesResponse>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<RolesResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<RolesResponse>))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(List<RolesResponse>))]
        [HttpGet]
        public async Task<IActionResult> GetAllRoless() => Ok(await _mediator.Send(new GetAllRolesQuery()));


        /// <summary>
        /// Exist Rol
        /// </summary>
        /// <param name="RolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesBoolResponse))]
        [HttpGet("requestExit/")]
        public async Task<bool> ExistRol([FromBody] RolesRequest RolRequest) => await _mediator.Send(new ExistRolesCommand { IdRoles = RolRequest.Id }); 
            
    }

}
