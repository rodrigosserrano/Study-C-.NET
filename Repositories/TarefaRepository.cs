using System.Text.Json;
using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class TarefaRepository : IRepository<TarefaModel>
{
    private readonly DBContext _dbContext;

    public TarefaRepository(DBContext dbContext) => _dbContext = dbContext;
    
    public async Task<TarefaModel?> Get(int id)
    {
        return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<TarefaModel>> GetAll()
    {
        return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .ToListAsync();
    }

    public async Task<TarefaModel> Add(TarefaModel tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();

        return tarefa;
    }

    public async Task<TarefaModel> Update(TarefaModel tarefa, int id)
    {
        TarefaModel taskRegistered = await Get(id) ?? throw new Exception($"Task id {id} not found");
            
        taskRegistered.Name = tarefa.Name;
        taskRegistered.Descricao = tarefa.Descricao;
        taskRegistered.Status = tarefa.Status;
        taskRegistered.UsuarioId = tarefa.UsuarioId;

        _dbContext.Tarefas.Update(taskRegistered);
        await _dbContext.SaveChangesAsync();

        return taskRegistered;
    }

    public async Task<bool> Delete(int id)
    {
        TarefaModel user = await Get(id) ?? throw new Exception($"Task id {id} not found");
        _dbContext.Tarefas.Remove(user);
        await _dbContext.SaveChangesAsync();
            
        return true;
    }
}