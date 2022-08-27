﻿using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly Lazy<ILogger<RolesController>> _logger;

        private readonly Lazy<IRolesServices> _rolesServices;

        public RolesController(Lazy<ILogger<RolesController>> logger, Lazy<IRolesServices> rolesServices)
        {
            _logger = logger;
            _rolesServices = rolesServices;
        }

        //CRUD

        /// <summary>
        /// GET Rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RolesViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(RolesViewModel))]
        [HttpGet("{idRol}")]
        public async Task<RolesViewModel> Get(int idRol) =>
             RolesMapper.Map(await _rolesServices.Value.GetRol(idRol));

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
            RolesMapper.Map(await _rolesServices.Value.AddRol(RolesMapper.Map(rol)));

        /// <summary>
        /// Delete Rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{idRol}")]
        public async Task<bool> DeleteRol(int idRol) => await _rolesServices.Value.DeleteRol(idRol);

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
            RolesMapper.Map(await _rolesServices.Value.UpdateRol(RolesMapper.Map(rol)));


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
             Ok(await _rolesServices.Value.GetAllRoles());
    }

}