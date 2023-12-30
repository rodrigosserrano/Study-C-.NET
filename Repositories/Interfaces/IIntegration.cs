using API.Models;

namespace API.Repositories.Interfaces;

public interface IIntegration<TModel>
{
    Task<TModel> Get(string cep);
}