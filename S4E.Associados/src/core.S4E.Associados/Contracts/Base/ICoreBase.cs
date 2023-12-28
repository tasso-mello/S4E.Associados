namespace core.S4E.Associados.Contracts.Base;

public interface ICoreBase<T> where T : class
{
    Task<string> Get(int id);
    Task<string> Get(int skip, int take);
    Task<string> Get(string filter, int skip, int take);
    Task<string> Post(T model);
    Task<string> Put(T model);
    Task<string> Delete(int id);
}
