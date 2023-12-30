using Refit;

namespace API.Repositories.Interfaces;

public interface IIntegrationRefit<TModelExternal>
{
    [Get("{path}")]
    Task<ApiResponse<TModelExternal>> Get(string path);
}