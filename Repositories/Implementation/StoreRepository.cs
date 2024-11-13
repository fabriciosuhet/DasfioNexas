using DesafioNexas.Entities;
using DesafioNexas.Infrastructure;

namespace DesafioNexas.Repositories.Implementation;

public class StoreRepository : IStoreRepository
{
    private readonly ProductDbContext _context;

    public StoreRepository(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task CadastrarLojaAsync(Store? store)
    {
        await _context.Stores.AddAsync(store);
        await _context.SaveChangesAsync();
    }

    public async Task AlterarLojaAsync(int id, Store? store)
    {
        await _context.Stores.FindAsync(id);
        _context.Stores.Update(store);
        await _context.SaveChangesAsync();
        
    }

    public async Task<Store?> ObterLojaPorIdAsync(int id)
    {
        return await _context.Stores.FindAsync(id);
    }

    public async Task RemoverLojaAsync(int id)
    {
        await _context.Stores.FindAsync(id);
        _context.Remove(id);
        await _context.SaveChangesAsync();

    }
}