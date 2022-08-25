using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
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
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpGet("{id}")]
        public async Task<RolesViewModel> Get(int id) =>
             RolesMapper.Map(await _rolesServices.GetRol(id));

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
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteRol(int id) => await _rolesServices.DeleteRol(id);

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
    }

}
