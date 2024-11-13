using DesafioNexas.Entities;

namespace DesafioNexas.Repositories;

public interface IStoreRepository
{
    Task CadastrarLojaAsync(Store? store);
    Task AlterarLojaAsync(int id, Store? store);
    Task<Store>? ObterLojaPorIdAsync(int id);
    Task RemoverLojaAsync(int id);
}