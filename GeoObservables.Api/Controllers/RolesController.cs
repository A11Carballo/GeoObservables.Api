using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Exceptions;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Request;
using GeoObservables.Api.Response.Roles;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;

        private readonly IRolesServices _rolesServices;

        public RolesController(ILogger<RolesController> logger, IRolesServices rolesServices)
        {
            this._logger = logger;
            this._rolesServices = rolesServices;
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
        public async Task<IActionResult> Get(int IdRol) 
        {
            try
            {
                var Response = new RolesResponse(RolesMapper.Map(await this._rolesServices.GetRol(IdRol)));

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesResponse(new List<RolesViewModel>(), ex));
            }
        }

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
        public async Task<IActionResult> AddRol([FromBody] RolesViewModel rol)
        {
            try
            {
                var Response = new RolesResponse(RolesMapper.Map(await this._rolesServices.AddRol(RolesMapper.Map(rol))));

                return Ok(Response);
            } 
            catch (GeneralException ex)
            {
                return BadRequest(new RolesResponse(new List<RolesViewModel>(), ex));
            }
        }

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
        public async Task<IActionResult> DeleteRol([FromBody] RolesViewModel Rol)  
        {
            try
            {
                var Response = new RolesBoolResponse(await this._rolesServices.DeleteRol(RolesMapper.Map(Rol)));

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesBoolResponse(ex));
            }
        }


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
        public async Task<IActionResult> UpdateRoles([FromBody] RolesViewModel rol)
        {
            try
            {
                var Response = new RolesResponse(RolesMapper.Map(await this._rolesServices.UpdateRol(RolesMapper.Map(rol))));

                return Ok(Response);
            }
            catch(GeneralException ex)
            {
                return BadRequest(new RolesResponse(new List<RolesViewModel>(), ex));
            }
        }

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
        public async Task<IActionResult> GetAlRoless()
        {
            try
            {
                var Response = new RolesResponse((await this._rolesServices.GetAllRoles()).Select(x => RolesMapper.Map(x)).ToList());

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesResponse(new List<RolesViewModel>(), ex));
            }
        }

        //Request

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
        public async Task<IActionResult> ExistRol([FromBody] RolesRequest RolRequest)
        {
            try
            {
                var Response = new RolesBoolResponse(await this._rolesServices.ExistRol(RolRequest.Id));

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesBoolResponse(ex));
            }
        }

        /// <summary>
        /// Delete Rol Request
        /// </summary>
        /// <param name="RolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesBoolResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesBoolResponse))]
        [HttpDelete("request/")]
        public async Task<IActionResult> DeleteRolRequest([FromBody] RolesRequest RolRequest)  
        {
            try
            {
                var Response = new RolesBoolResponse(await this._rolesServices.DeleteRolRequest(RolRequest.Id));

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesBoolResponse(ex));
            }
        }

        /// <summary>
        /// GET Rol Request
        /// </summary>
        /// <param name="RolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesResponse))]
        [HttpGet("request/{RolRequest}")]
        public async Task<IActionResult> GetRequest([FromBody] RolesRequest RolRequest)
        {
            try
            {
                var Response = new RolesResponse(RolesMapper.Map(await this._rolesServices.GetRolRequest(RolRequest.Id)));

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesResponse(new List<RolesViewModel>(), ex));
            }
        }
        

        /// <summary>
        /// GET Rol By Rol Request
        /// </summary>
        /// <param name="RolesRolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesResponse))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesResponse))]
        [HttpGet("rolbyrolrequest/{RolesRolRequest}")]
        public async Task<IActionResult> GetRolByRolRequest([FromBody] RolesRolRequest RolbyRolRequest)
        {
            try
            {
                var Response = new RolesResponse(RolesMapper.Map(await this._rolesServices.GetRolByRol(RolbyRolRequest.Role)));

                return Ok(Response);
            }
            catch (GeneralException ex)
            {
                return BadRequest(new RolesResponse(new List<RolesViewModel>(), ex));
            }
        }
            
    }

}
