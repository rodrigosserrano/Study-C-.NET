using API.Models;
using API.Repositories.Interfaces;

namespace API.Repositories;

public class ViaCepRepository : IIntegration<ViaCepModel>
{
    private readonly IRefit<ViaCepModel> _refit;
    public ViaCepRepository(IRefit<ViaCepModel> refit) => _refit = refit;
    
    public async Task<ViaCepModel> Get(string cep)
    {
        var response = await _refit.Get($"/ws/{cep}/json");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response?.Error != null 
                ? response.Error.Content 
                : "Unknow error from \'Via Cep\'"
            );
        }
        
        if (response.Content.Cep == null) {
            throw new Exception(response?.Error != null 
                ? response.Error.Content 
                : "Nullable data"
            );
        }
        
        return response.Content;
    }
}