using DesafioNexas.Entities;
using DesafioNexas.Interface.Interfaces;
using DesafioNexas.Repositories;

namespace DesafioNexas.Interface.Implementation;

public class StockItemService : IStockItemService
{
    private readonly IStockItemRepository _stockItemRepository;

    public StockItemService(IStockItemRepository stockItemRepository)
    {
        _stockItemRepository = stockItemRepository;
    }
    
    public async Task CriarItemEstoque(StockItem stockItem)
    {
        if (stockItem == null)
        {
            throw new ArgumentNullException(nameof(stockItem), "O estoque item não pode ser vázio");
        }
        await _stockItemRepository.CriarEstoqueAsync(stockItem);
    }

    public async Task AdicionarItemProdutoNoEstoque(StockItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "O item não pode ser vázio");
        }

        await _stockItemRepository.AdicionarItemEstoqueAsync(item);
    }

    public async Task RemoverItemProdutoNoEstoque(StockItem item, int removerQuantidade)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "O item não pode ser vázio");
        }

        if (removerQuantidade < 0 || removerQuantidade > item.Quantity)
        {
            throw new InvalidOperationException("O valor não pode ser menor que zero nem maior que a quantidade atual");
        }

        await _stockItemRepository.RetirarItemEstoqueAsync(removerQuantidade, item);
    }

    public async Task AtualizarItemProdutoNoEstoque(StockItem item, int atualizarQuantidade)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "O item não pode ser vázio");
        }

        if (atualizarQuantidade < 0 )
        {
            throw new InvalidOperationException("O valor não pode ser menor que zero");
        }
        
        await _stockItemRepository.AtualizarItemEstoqueAsync(atualizarQuantidade, item);
    }
}