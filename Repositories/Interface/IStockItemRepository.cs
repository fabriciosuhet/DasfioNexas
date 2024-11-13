using DesafioNexas.Entities;

namespace DesafioNexas.Repositories;

public interface IStockItemRepository
{
    Task AdicionarItemEstoqueAsync(StockItem stockItem);
    Task AtualizarItemEstoqueAsync(int novaQuantidade, StockItem stockItem);
    Task RetirarItemEstoqueAsync(int retirarQuantidade, StockItem stockItem);
    Task CriarEstoqueAsync(StockItem stockItem);
}