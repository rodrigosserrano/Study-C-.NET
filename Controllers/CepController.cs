using API.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase
{
    private readonly IIntegration<ViaCepModel> _external;
    public CepController(IIntegration<ViaCepModel> external) => _external = external;

    [HttpGet("{cep}")]
    public async Task<ActionResult<ViaCepModel>> Get(string cep)
    {
        try {
            var response = await _external.Get(cep);
            return Ok(response);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

}