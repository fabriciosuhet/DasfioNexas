using System.ComponentModel.DataAnnotations;

namespace DesafioNexas.Entities;

public class Store : BaseEntity
{
    [MaxLength(250)]
    public string? Name { get; private set; }
    
    [MaxLength(250)]
    public string? Address { get; private set; }
    public ICollection<StockItem>? StockItems { get; private set; } = new List<StockItem>();

    public Store()
    {
    }

    public Store(string? name, string? address, ICollection<StockItem>? stockItems)
    {
        Name = name;
        Address = address;
        StockItems = stockItems ?? new List<StockItem>();
    }

    public void AlterarNome(string? novoNome)
    {
        Name = novoNome;
    }

    public void AlterarEndereço(string? novoEndereco)
    {
        Address = novoEndereco;
    }
}