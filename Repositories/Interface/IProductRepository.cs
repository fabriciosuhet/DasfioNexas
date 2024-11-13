
using DesafioNexas.Entities;

namespace DesafioNexas.Repositories;

public interface IProductRepository
{
    Task CadastrarProdutoAsync(Product? product);
    Task AlterarProdutoAsync(int id, Product? product);
    Task<Product?>? ObterProdutoPorIdAsync(int id);
    Task RemoverProdutoAsync(int id);
}