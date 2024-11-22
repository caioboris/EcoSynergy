using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces.Dtos;
using FluentValidation;

namespace FIAP.GlobalSolution.EcoSynergy.Application.Dtos;

public class PainelDTO : IPainelDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public double ProducaoMedia { get; set; }

    public void Validate()
    {
        var validateResult = new PainelValidation().Validate(this);

        if (validateResult.IsValid)
            throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
    }

    internal class PainelValidation : AbstractValidator<PainelDTO>
    {
        public PainelValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage($"o Campo {nameof(PainelDTO.Nome)} deve ter no mínimo 3 caracteres.")
                .NotEmpty().WithMessage($"o Campo {nameof(PainelDTO.Nome)} não pode ser vazio.");

            RuleFor(x => x.ProducaoMedia)
                .GreaterThan(0).WithMessage($"o Campo {nameof(PainelDTO.ProducaoMedia)} deve ter ser maior do que 0.");
        }
    }
}

internal static class PainelMapper
{
    public static IPainelDTO ToDto(this Painel entity)
    {
        return new PainelDTO
        {
            Id = entity.Id,
            Nome = entity.Nome,
            ProducaoMedia = entity.ProducaoMedia,
        };
    }

    public static Painel ToEntity(this IPainelDTO dto)
    {
        return new Painel
        {
            Id = dto.Id,
            Nome = dto.Nome,
            ProducaoMedia = dto.ProducaoMedia
        };
    }
}
