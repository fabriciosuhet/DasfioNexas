using DesafioNexas.Entities;
using DesafioNexas.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DesafioNexas.Repositories.Implementation;

public class StockItemRepository : IStockItemRepository
{
    private readonly ProductDbContext _context;

    public StockItemRepository(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task AdicionarItemEstoqueAsync(StockItem stockItem)
    {
        await _context.StockItems.AddAsync(stockItem);
        await _context.SaveChangesAsync();
    }
    
    public async Task AtualizarItemEstoqueAsync(int novaQuantidade, StockItem stockItem)
    {
        stockItem.AtualizarQuantidade(novaQuantidade);
        _context.StockItems.Update(stockItem);
        await _context.SaveChangesAsync();

    }

    public async Task RetirarItemEstoqueAsync(int retirarQuantidade, StockItem stockItem)
    {
        stockItem.RetirarItemEstoque(retirarQuantidade);
        _context.StockItems.Remove(stockItem);
        await _context.SaveChangesAsync();
    }
    
    public async Task CriarEstoqueAsync(StockItem stockItem)
    {
        await _context.StockItems.AddAsync(stockItem);
        await _context.SaveChangesAsync();
    }
}