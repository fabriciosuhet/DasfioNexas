
using DesafioNexas.Entities;

namespace DesafioNexas.Interface.Interfaces;

public interface IProductService
{
    Task CadastrarProdutoAsync(Product? product);
    Task <Product> ObterProdutoPorIdAsync(int id);
    Task AlterarProdutoAsync(int id, Product product);
    Task RemoverProdutoAsync(int id);
}