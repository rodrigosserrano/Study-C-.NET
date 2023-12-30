using System.ComponentModel;

namespace API.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        ToDo = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluido")]
        Done = 3,
    }
}
