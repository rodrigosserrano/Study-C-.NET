using API.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly IRepository<TarefaModel> _repository;
    public TarefaController(IRepository<TarefaModel> repository) => _repository = repository;
    
    [HttpGet]
    public async Task<ActionResult<List<TarefaModel>>> GetAll() => Ok(await _repository.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaModel>> GetById(int id) => Ok(await _repository.Get(id));

    [HttpPost]
    public async Task<ActionResult<TarefaModel>> Create([FromBody] TarefaModel tarefaModel) => Ok(await _repository.Add(tarefaModel));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaModel>> Update([FromBody] TarefaModel tarefaModel, int id)
    {
        tarefaModel.Id = id;
        return Ok(await _repository.Update(tarefaModel, id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id) => Ok(await _repository.Delete(id));
}