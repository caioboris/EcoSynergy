namespace FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces;

public interface IBaseRepository<T>
{
    T? ObterPorId(int id);  
    IEnumerable<T> ObterTodos();
    bool Inserir(T entity);
    bool Atualizar(int id, T entity);
    bool Deletar(int id);
}