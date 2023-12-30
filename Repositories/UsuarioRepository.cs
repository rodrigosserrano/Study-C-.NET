using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;
public class UsuarioRepository : IRepository<UsuarioModel>
{
    private readonly DBContext _dbContext;
    public UsuarioRepository(DBContext dbContext) => _dbContext = dbContext;
    
    public async Task<UsuarioModel?> Get(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<UsuarioModel>> GetAll()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> Add(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
    {
        UsuarioModel userRegistered = await Get(id) ?? throw new Exception($"User id {id} not found");
        
        userRegistered.Email = usuario.Email;
        userRegistered.Name = usuario.Name;

        _dbContext.Usuarios.Update(userRegistered);
        await _dbContext.SaveChangesAsync();

        return userRegistered;
    }

    public async Task<bool> Delete(int id)
    {
        UsuarioModel user = await Get(id) ?? throw new Exception($"User id {id} not found");
        _dbContext.Usuarios.Remove(user);
        await _dbContext.SaveChangesAsync();
        
        return true;
    }
}
