namespace pc202302.Logistics.Domain.Model.Aggregates;

public partial class Inventory
{

    public Inventory(int productId, int warehouseId, int minimumStock, int currentStock)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        MinimumStock = minimumStock;
        CurrentStock = currentStock;
    }

    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int MinimumStock { get; set; }
    public int CurrentStock { get; set; }
    
}