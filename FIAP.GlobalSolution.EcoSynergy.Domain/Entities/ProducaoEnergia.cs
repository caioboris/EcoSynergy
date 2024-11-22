using System.ComponentModel.DataAnnotations;

namespace FIAP.GlobalSolution.EcoSynergy.Domain.Entities;

public class ProducaoEnergia
{
    [Key]
    public int Id { get; set; } 
    public DateTime Timestamp { get; set; }  // Data e hora da leitura
    public double PotenciaGerada { get; set; } // Em kWh
    public double TemperaturaAmbiente { get; set; }
    public IEnumerable<Painel> Paineis { get; set; } 
}
