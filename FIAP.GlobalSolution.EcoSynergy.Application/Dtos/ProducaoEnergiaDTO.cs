using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces.Dtos;
using FluentValidation;

namespace FIAP.GlobalSolution.EcoSynergy.Application.Dtos;

public class ProducaoEnergiaDTO : IProducaoEnergiaDTO
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public double PotenciaGerada { get; set; }
    public double TemperaturaAmbiente { get; set; }
    public IEnumerable<Painel> Paineis { get; set; } = [];

    public void Validate()
    {
        var validateResult = new ProducaoEnergiaValidation().Validate(this);

        if (validateResult.IsValid)
            throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
    }

    internal class ProducaoEnergiaValidation : AbstractValidator<ProducaoEnergiaDTO>
    {
        public ProducaoEnergiaValidation()
        {
            RuleFor(x => x.PotenciaGerada)
                .GreaterThan(0).WithMessage($"o Campo {nameof(ProducaoEnergiaDTO.PotenciaGerada)} deve ter ser maior do que 0.");

            RuleFor(x => x.TemperaturaAmbiente)
                .GreaterThan(0).WithMessage($"o Campo {nameof(ProducaoEnergiaDTO.TemperaturaAmbiente)} deve ter ser maior do que 0.");
        }
    }
}

internal static class ProducaoEnergiaMapper
{
    public static IProducaoEnergiaDTO ToDto(this ProducaoEnergia entity)
    {
        return new ProducaoEnergiaDTO
        {
            Id = entity.Id,
            Paineis = entity.Paineis,
            PotenciaGerada = entity.PotenciaGerada,
            TemperaturaAmbiente = entity.TemperaturaAmbiente,
            Timestamp = entity.Timestamp,
        };
    }

    public static ProducaoEnergia ToEntity(this IProducaoEnergiaDTO dto)
    {
        return new ProducaoEnergia
        {
            Id = dto.Id,
            Paineis = dto.Paineis,
            PotenciaGerada = dto.PotenciaGerada,
            TemperaturaAmbiente = dto.TemperaturaAmbiente,
            Timestamp = dto.Timestamp,
        };
    }
}

