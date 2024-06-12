using pc202302.Logistics.Domain.Model.Commands;

namespace pc202302.Logistics.Domain.Model.Aggregates;

///  <summary>
/// Represents an inventory of a product in a warehouse.
/// </summary>
/// <remarks>
/// Salvador Salinas
/// </remarks>
public partial class Inventory
{

    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class.
    /// </summary>
    /// <param name="productId"> the id of the product </param>
    /// <param name="warehouseId"> the id of the warehouse </param>
    /// <param name="minimumStock"> the minimum stock </param>
    /// <param name="currentStock"> the current stock </param>
    public Inventory(int productId, int warehouseId, int minimumStock, int currentStock)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        MinimumStock = minimumStock;
        CurrentStock = currentStock;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class.
    /// </summary>
    /// <param name="command"> the command to create an inventory </param>
    public Inventory(CreateInventoryCommand command)
    {
        ProductId = command.ProductId;
        WarehouseId = command.WarehouseId;
        MinimumStock = command.MinimumStock;
        CurrentStock = command.CurrentStock;
    }

    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int MinimumStock { get; set; }
    public int CurrentStock { get; set; }
    
}