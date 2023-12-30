using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;
        
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAll()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel?>> GetById(int id)
        {
            UsuarioModel? usuario = await _usuarioRepository.Get(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.Add(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepository.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id) => Ok(await _usuarioRepository.Delete(id));
        
    }
}