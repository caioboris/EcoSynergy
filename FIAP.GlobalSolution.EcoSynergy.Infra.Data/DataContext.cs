using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<ProducaoEnergia> ProducoesEnergia { get; set; }
    public DbSet<Painel> Paineis { get; set; }
}
