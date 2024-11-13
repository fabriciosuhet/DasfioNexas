using System.ComponentModel.DataAnnotations;


namespace DesafioNexas.Entities;

public class Product : BaseEntity
{
    [MaxLength(250)]
    public string? Name { get; private set; }
    public double? CostPrice { get; private set; }
    public ICollection<StockItem>? StockItems { get; private set; } = new List<StockItem>();

    public Product()
    {
    }
    

    public Product(string? name, double? costPrice, ICollection<StockItem>? stockItems)
    {
        Name = name;
        CostPrice = costPrice;
        StockItems = stockItems ?? new List<StockItem>();
    }

    public void AtualizarNome(string? name)
    {
        Name = name;
    }

    public void AtualizarPreco(double? costPrice)
    {
        CostPrice = costPrice;
    }
}