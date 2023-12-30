using API.Enums;

namespace API;

public class TarefaModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefa Status { get; set; }
}
