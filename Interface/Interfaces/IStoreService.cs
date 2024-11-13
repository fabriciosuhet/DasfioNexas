using DesafioNexas.Entities;

namespace DesafioNexas.Interface.Interfaces;

public interface IStoreService
{
    Task CadastrarLojaAsync(Store? store);
    Task <Store?>? ObterLojaPorIdAsync(int id);
    Task AlterarLojaAsync(int id, Store? store);
    Task RemoverLojaAsync(int id);
}