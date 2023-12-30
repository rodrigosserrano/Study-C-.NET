using Refit;

namespace API.Repositories.Interfaces;

public interface IRefit<TModelExternal>
{
    [Get("/{path}")]
    Task<ApiResponse<TModelExternal>> Get(string path);
}