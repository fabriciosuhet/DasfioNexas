namespace DesafioNexas.Entities;

public class StockItem : BaseEntity
{
    public int? StoreId { get; private set; }
    public int? ProductId { get; private set; }
    public int? Quantity { get; private set; }
    public Product? Product { get;  private set; }
    public Store? Store { get;  private set; }

    public StockItem()
    {
    }

    public StockItem(Store? store, Product? product, int? quantity)
    {
        Store = store;
        Product = product;
        StoreId = store?.Id;
        ProductId = product?.Id;
        Quantity = quantity;
    }

    public void AtualizarQuantidade(int novaQuantidade)
    {
        if (novaQuantidade < 0)
        {
            throw new InvalidOperationException("A quantidade não pode ser negativa.");
        }

        Quantity = novaQuantidade;
    }

    public void RetirarItemEstoque(int retirarItem)
    {
        if (retirarItem <= 0)
        {
            throw new ArgumentException("A quantidade deve ser superior a zero");
        }

        if (retirarItem > Quantity)
        {
            throw new InvalidOperationException("Quantidade insuficiente no estoque");
        }
        
        Quantity -= retirarItem;
    }
}