using FIAP.GlobalSolution.EcoSynergy.Application.Dtos;
using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces.Dtos;

namespace FIAP.GlobalSolution.EcoSynergy.Application.Services;

public class ProducaoEnergiaService : IProducaoEnergiaService
{
    private readonly IProducaoEnergiaRepository _repository;

    public ProducaoEnergiaService(IProducaoEnergiaRepository repository)
    {
        _repository = repository;
    }

    public bool Atualizar(int id, IProducaoEnergiaDTO entity)
    {
        return _repository.Atualizar(id, entity.ToEntity());
    }

    public bool Deletar(int id)
    {
        return _repository.Deletar(id); 
    }

    public bool Inserir(IProducaoEnergiaDTO entity)
    {
        return _repository.Inserir(entity.ToEntity());
    }

    public IProducaoEnergiaDTO? ObterPorId(int id)
    {
        return _repository.ObterPorId(id)?.ToDto();
    }

    public IEnumerable<IProducaoEnergiaDTO> ObterTodos()
    {
        return _repository.ObterTodos().Select(x => x.ToDto());
    }
}
