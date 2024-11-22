using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data.Repositories;

public class ProducaoEnergiaRepository : IProducaoEnergiaRepository
{
    private readonly DataContext _context;

    public ProducaoEnergiaRepository(DataContext context)
    {
        _context = context;
    }

    public bool Atualizar(int id, ProducaoEnergia entity)
    {
        var producao = _context.ProducoesEnergia.Find(id);

        if (producao is null)
        {
            return false;
        }

        producao.Paineis = entity.Paineis;
        producao.PotenciaGerada = entity.PotenciaGerada;
        producao.TemperaturaAmbiente = entity.TemperaturaAmbiente;
        producao.Timestamp = entity.Timestamp;

        _context.ProducoesEnergia.Update(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public bool Deletar(int id)
    {
        var entity = _context.ProducoesEnergia.Find(id);

        if (entity is null)
        {
            return false;
        }
        _context.ProducoesEnergia.Remove(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public bool Inserir(ProducaoEnergia entity)
    {
        _context.ProducoesEnergia.Add(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public ProducaoEnergia? ObterPorId(int id)
    {
        return _context.ProducoesEnergia
            .Include(x => x.Paineis)
            .FirstOrDefault(y => y.Id == id);
    }

    public IEnumerable<ProducaoEnergia> ObterTodos()
    {
        return _context.ProducoesEnergia
            .Include(x => x.Paineis)
            .ToList();
    }
}
