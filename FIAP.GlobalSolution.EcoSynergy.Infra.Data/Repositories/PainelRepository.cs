using FIAP.GlobalSolution.EcoSynergy.Domain.Entities;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces;

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data.Repositories;

public class PainelRepository : IPainelRepository
{
    private readonly DataContext _context;

    public PainelRepository(DataContext context)
    {
        _context = context;
    }

    public bool Atualizar(int id, Painel entity)
    {
        var painel = _context.Paineis.Find(id);

        if (painel is null)
        {
            return false;
        }

        painel.Nome = entity.Nome;
        painel.ProducaoMedia = entity.ProducaoMedia;

        _context.Paineis.Update(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public bool Deletar(int id)
    {
        var entity = _context.Paineis.Find(id);
        
        if(entity is null)
        {
            return false;
        }
        _context.Paineis.Remove(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public bool Inserir(Painel entity)
    {
        _context.Paineis.Add(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public Painel? ObterPorId(int id)
    {
        return _context.Paineis.Find(id);
    }

    public IEnumerable<Painel> ObterTodos()
    {
        return _context.Paineis.ToList();
    }
}
