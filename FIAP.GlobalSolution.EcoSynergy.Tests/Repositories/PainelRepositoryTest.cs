using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;
using FIAP.GlobalSolution.EcoSynergy.Infra.Data;
using FIAP.GlobalSolution.EcoSynergy.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIAP.GlobalSolution.EcoSynergy.Tests.Repositories;

public class PainelRepositoryTest
{
    private readonly DbContextOptions<DataContext> _options;
    private readonly DataContext _context;
    private readonly PainelRepository _repository;

    public PainelRepositoryTest()
    {
        _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new DataContext(_options);
        _repository = new PainelRepository(_context);
    }

    [Fact]
    public void Adicionar_DeveAdicionarClienteERetornarPainel()
    {
        // Arrange
        var sensor = new Painel { Id = 10, Nome = "Painel 1", ProducaoMedia = 24.0 };

        // Act
        var resultado = _repository.Inserir(sensor);

        // Assert
        var sensorNoDb = _context.Paineis.FirstOrDefault(c => c.Id == sensor.Id);
        Assert.NotNull(sensorNoDb);
        Assert.Equal(sensor.Id, sensorNoDb.Id);
        Assert.Equal(sensor.Nome, sensorNoDb.Nome);
    }

    [Fact]
    public void Editar_DeveAtualizarPainelERetornarPainel_QuandoPainelExiste()
    {
        // Arrange
        var sensor = new Painel { Id = 21, Nome = "Painel 1", ProducaoMedia = 24.0 };

        _context.Paineis.Add(sensor);
        _context.SaveChanges();

        sensor.Nome = "Painel Atualizado";

        // Act
        var resultado = _repository.Atualizar(sensor.Id, sensor);

        // Assert
        var sensorNoDb = _context.Paineis.FirstOrDefault(c => c.Id == sensor.Id);
        Assert.NotNull(sensorNoDb);
        Assert.Equal("Painel Atualizado", sensorNoDb.Nome);
    }

    [Fact]
    public void ObterPorId_DeveRetornarPainel_QuandoClienteExiste()
    {
        // Arrange
        var sensor = new Painel { Id = 31, Nome = "Painel 1", ProducaoMedia = 24.0 };
        _context.Paineis.Add(sensor);
        _context.SaveChanges();

        // Act
        var resultado = _repository.ObterPorId(sensor.Id);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(sensor.Id, resultado.Id);
        Assert.Equal(sensor.Nome, resultado.Nome);
    }

    [Fact]
    public void ObterTodos_DeveRetornarListaDeClientes_QuandoExistiremClientes()
    {
        _context.Paineis.RemoveRange(_context.Paineis.ToList());
        // Arrange
        var sensores = new List<Painel>
        {
            new Painel { Id = 212, Nome = "Painel 1", ProducaoMedia = 24.0 },
            new Painel { Id = 311, Nome = "Painel 2", ProducaoMedia = 14.0 }
        };
        _context.Paineis.AddRange(sensores);
        _context.SaveChanges();

        // Act
        var resultado = _repository.ObterTodos();

        // Assert
        Assert.Equal(sensores.Count, resultado.Count());
        Assert.Equal(sensores[0].Nome, resultado.First().Nome);
        Assert.Equal(sensores[1].Nome, resultado.Last().Nome);
    }

    [Fact]
    public void Remover_DeveRemoverClienteERetornarPainel_QuandoClienteExiste()
    {
        // Arrange
        var sensor = new Painel { Id = 3211, Nome = "Painel 1", ProducaoMedia = 24.0 };
        _context.Paineis.Add(sensor);
        _context.SaveChanges();

        // Act
        var resultado = _repository.Deletar(sensor.Id);

        // Assert
        var sensorNoDb = _context.Paineis.FirstOrDefault(c => c.Id == sensor.Id);

        Assert.Null(sensorNoDb);
        Assert.True(resultado);
    }
}


