using FIAP.GlobalSolution.EcoSynergy.Application.Dtos;
using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces.Dtos;

namespace FIAP.GlobalSolution.EcoSynergy.Application.Services;

public class PainelService : IPainelService
{
    private readonly IPainelRepository _repository;

    public PainelService(IPainelRepository repository)
    {
        _repository = repository;
    }

    public bool Atualizar(int id, IPainelDTO entity)
    {
        return _repository.Atualizar(id, entity.ToEntity());
    }

    public bool Deletar(int id)
    {
        return _repository.Deletar(id);
    }

    public bool Inserir(IPainelDTO entity)
    {
        return _repository.Inserir(entity.ToEntity());
    }

    public IPainelDTO? ObterPorId(int id)
    {
        return _repository.ObterPorId(id)?.ToDto();  
    }

    public IEnumerable<IPainelDTO> ObterTodos()
    {
        return _repository.ObterTodos().Select(x => x.ToDto());
    }
}
