using API.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IRepository<UsuarioModel> _repository;
    public UsuarioController(IRepository<UsuarioModel> repository) => _repository = repository;
    
    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> GetAll() => Ok(await _repository.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel?>> GetById(int id) => Ok(await _repository.Get(id));
    
    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel) => Ok(await _repository.Add(usuarioModel));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
    {
        usuarioModel.Id = id;
        return Ok(await _repository.Update(usuarioModel, id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id) => Ok(await _repository.Delete(id));
    
}
