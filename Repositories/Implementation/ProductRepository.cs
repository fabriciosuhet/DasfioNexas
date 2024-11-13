using DesafioNexas.Entities;
using DesafioNexas.Infrastructure;

namespace DesafioNexas.Repositories.Implementation;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task CadastrarProdutoAsync(Product? product)
    {
        _context.Products?.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task AlterarProdutoAsync(int id, Product? product)
    {
        await _context.Products.FindAsync(id);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product?>? ObterProdutoPorIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
        
    }

    public async Task RemoverProdutoAsync(int id)
    {
        await _context.Products.FindAsync(id);
        _context.Remove(id);
        await _context.SaveChangesAsync();
    }
}