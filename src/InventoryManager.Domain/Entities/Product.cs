namespace InventoryManager.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int QuantityInStock { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private Product()
    {
    }

    public Product(Guid id, string name, string description, decimal price, int quantityInStock, DateTime createdAt, DateTime updatedAt)
    {
        Id = Guid.NewGuid;
        Name = name;
        Description = description;
        Price = price;
        QuantityInStock = quantityInStock;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Update(String name, String description, decimal price)
    {

        ValidateName(name);
        ValidatePrice(price);

        Name = name;
        Description = description;
        Price = price;
        UpdatedAt = DateTime.UtcNow;

    }

    public void AddStock(int quantity)
    {

        ValidateQuantity(quantity);

        QuantityInStock += quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveStock(int quantity)
    {
        ValidateQuantity(quantity);

        if (quantity > QuantityInStock)
        {
            throw new InvalidOperationException(
                "Estoque Insuficiente.");
        }
    }

}
