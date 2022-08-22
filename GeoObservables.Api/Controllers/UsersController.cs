using GeoObservables.Api.Aplication.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersServices _usersServices;

        public UsersController(ILogger<UsersController> logger, IUsersServices usersServices)
        {
            _logger = logger;
            _usersServices= usersServices;
        }

        //CRUD

        // GET api/model/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _usersServices.GetUser(id);

            return Ok(entity);
        } //=> await _usersServices.GetUser(id);

        //POST api/values
     /*   [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModelRequest request)
        {
            var entity = new ModelViewModel
            {
                EsCliente = true,
                Nombre = request.Nombre
            };
            await _modelService.AddModel(ModelModelMapper.Map(entity));

            return Ok();
        }*/

    }
}
