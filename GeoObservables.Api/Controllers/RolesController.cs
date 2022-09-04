using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Request;
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
            _logger = logger;
            _rolesServices = rolesServices;
        }

        //CRUD

        /// <summary>
        /// GET Rol
        /// </summary>
        /// <param name="Rol"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpGet("{Rol}")]
        public async Task<RolesViewModel> Get([FromBody] RolesViewModel Rol) =>
             RolesMapper.Map(await _rolesServices.GetRol(RolesMapper.Map(Rol)));


        /// <summary>
        /// POST Rol
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpPost]
        public async Task<RolesViewModel> AddRol([FromBody] RolesViewModel rol) =>
            RolesMapper.Map(await _rolesServices.AddRol(RolesMapper.Map(rol)));

        /// <summary>
        /// Delete Rol
        /// </summary>
        /// <param name="Rol"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{Rol}")]
        public async Task<bool> DeleteRol([FromBody] RolesViewModel Rol) => await _rolesServices.DeleteRol(RolesMapper.Map(Rol));


        /// <summary>
        /// PUT Rol
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpPut]
        public async Task<RolesViewModel> UpdateRoles([FromBody] RolesViewModel rol) =>
            RolesMapper.Map(await _rolesServices.UpdateRol(RolesMapper.Map(rol)));


        /// <summary>
        /// GET All Roles
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(List<RolesViewModel>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RolesViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<RolesViewModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<RolesViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<RolesViewModel>))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(List<RolesViewModel>))]
        [HttpGet]
        public async Task<IActionResult> GetAlRoless() =>
             Ok(await _rolesServices.GetAllRoles());

        /// <summary>
        /// Exist Rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpGet("request/exist/{RolRequest}")]
        public async Task<bool> ExistRol([FromBody] RolesRequest RolRequest) =>  await _rolesServices.ExistRol(RolRequest.Id);

        /// <summary>
        /// Delete Rol Request
        /// </summary>
        /// <param name="RolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("request/{RolRequest}")]
        public async Task<bool> DeleteRolRequest([FromBody] RolesRequest RolRequest) => await _rolesServices.DeleteRolRequest(RolRequest.Id);

        /// <summary>
        /// GET Rol Request
        /// </summary>
        /// <param name="RolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpGet("request/{RolRequest}")]
        public async Task<RolesViewModel> GetRequest([FromBody] RolesRequest RolRequest) =>
             RolesMapper.Map(await _rolesServices.GetRolRequest(RolRequest.Id));

        /// <summary>
        /// GET Rol By Rol Request
        /// </summary>
        /// <param name="RolesRolRequest"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpGet("rolbyrolrequest/{RolesRolRequest}")]
        public async Task<RolesViewModel> GetRolByRolRequest([FromBody] RolesRolRequest RolbyRolRequest) =>
             RolesMapper.Map(await _rolesServices.GetRolByRol(RolbyRolRequest.Role));
    }

}
