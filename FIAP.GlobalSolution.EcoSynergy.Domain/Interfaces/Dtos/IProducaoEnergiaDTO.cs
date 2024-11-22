using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;

namespace FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces.Dtos;

public interface IProducaoEnergiaDTO
{
    int Id { get; set; }
    DateTime Timestamp { get; set; } 
    double PotenciaGerada { get; set; }
    double TemperaturaAmbiente { get; set; }
    public IEnumerable<Painel> Paineis { get; set; } 
}

