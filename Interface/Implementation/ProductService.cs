
using DesafioNexas.Entities;
using DesafioNexas.Interface.Interfaces;
using DesafioNexas.Repositories;

namespace DesafioNexas.Interface.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    
    public async Task CadastrarProdutoAsync(Product? product)
    {

        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "O Produto não pode ser nulo.");
        }

        if (string.IsNullOrEmpty(product.Name))
        {
            throw new ArgumentException("O nome do produto não pode ser nulo ou vázio");
        }
        
        if (product.Name.Length > 250)
        {
            throw new ArgumentException("O nome do produto não pode ser maior que 250 caracteres");
        }

        if (product.CostPrice < 0)
        {
            throw new InvalidOperationException("O valor do produto não pode ser negativo");
        }
        
        await _productRepository.CadastrarProdutoAsync(product);
        
    }

    public async Task<Product> ObterProdutoPorIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("O ID do produto não pode ser negativo");
        }
        
        var produto = await _productRepository.ObterProdutoPorIdAsync(id);

        if (produto == null)
        {
            throw new Exception("O produto não existe ou não foi encontrado");
        }
        
        return produto;
    }

    public async Task AlterarProdutoAsync(int id, Product? productAtualizado)
    {
        if (productAtualizado == null)
        {
            throw new ArgumentNullException(nameof(productAtualizado), "O produto não pode ser nulo");
        }
        
        var produtoExistente = await _productRepository.ObterProdutoPorIdAsync(id);

        if (produtoExistente == null)
        {
            throw new Exception("O produto não existe ou não foi encontrado");
        }

        if (string.IsNullOrWhiteSpace(productAtualizado.Name))
        {
            throw new ArgumentException("O nome não pode ser nulo ou vázio");
        }

        if (productAtualizado.Name.Length > 250)
        {
            throw new ArgumentException("O nome do produto não pode ter mais de 250 caracteres");
        }

        if (productAtualizado.CostPrice == null || productAtualizado.CostPrice < 0)
        {
            throw new InvalidOperationException("O valor do produto deve ser maior ou igual a zero");
        }

        produtoExistente.AtualizarNome(productAtualizado.Name);
        produtoExistente.AtualizarPreco(productAtualizado.CostPrice);
        
        await _productRepository.AlterarProdutoAsync(id, productAtualizado);
    }

    public async Task RemoverProdutoAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("O valor do ID não pode ser negativo");
        } 
        
        var produto = await _productRepository.ObterProdutoPorIdAsync(id);
        if (produto == null)
        {
            throw new Exception("O Produto não existe ou não foi encontrado");
        }
        
        await _productRepository.RemoverProdutoAsync(id);
    }
}