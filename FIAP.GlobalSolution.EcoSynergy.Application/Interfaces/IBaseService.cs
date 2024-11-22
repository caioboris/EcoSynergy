namespace FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;

public interface IBaseService<T>
{
    T? ObterPorId(int id);
    IEnumerable<T> ObterTodos();
    bool Inserir(T entity);
    bool Atualizar(int id, T entity);
    bool Deletar(int id);
}