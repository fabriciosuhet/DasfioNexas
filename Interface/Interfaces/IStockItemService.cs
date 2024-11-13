using DesafioNexas.Entities;

namespace DesafioNexas.Interface.Interfaces;

public interface IStockItemService
{
    Task CriarItemEstoque(StockItem stockItem);
    Task AdicionarItemProdutoNoEstoque(StockItem item);
    Task RemoverItemProdutoNoEstoque(StockItem item, int removerQuantidade);
    Task AtualizarItemProdutoNoEstoque(StockItem item, int atualizarQuantidade);
}