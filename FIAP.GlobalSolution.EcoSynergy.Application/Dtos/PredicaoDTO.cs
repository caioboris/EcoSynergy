namespace FIAP.GlobalSolution.EcoSynergy.Application.Dtos;

public record PredicaoDTO
{
    /// <summary>
    /// Valor de luminosidade que deseja prever a produção
    /// </summary>
    public float ValorLuminosidade { get; set; }

    /// <summary>
    /// Quantidade de paineis
    /// </summary>
    public int QuantidadePaineis { get; set; }

    /// <summary>
    /// Producao media por painel
    /// </summary>
    public float ProducaoMediaPorPainel { get; set; }
}
