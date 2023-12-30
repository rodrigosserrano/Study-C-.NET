namespace API.Repositories.Interfaces;

public interface IRepository<TModel>
{
    Task<List<TModel>> GetAll();
    Task<TModel?> Get(int id);
    Task<TModel> Add(TModel model);
    Task<TModel> Update(TModel model, int id);
    Task<bool> Delete(int id);
}

