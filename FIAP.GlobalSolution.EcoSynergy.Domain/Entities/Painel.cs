using System.ComponentModel.DataAnnotations;

namespace FIAP.GlobalSolution.EcoSynergy.Domain.Entities;

public class Painel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    public double ProducaoMedia { get; set; }
}
