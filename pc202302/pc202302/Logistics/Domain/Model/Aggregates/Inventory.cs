﻿using pc202302.Logistics.Domain.Model.Commands;
using pc202302.Logistics.Domain.Model.ValueObjects;

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
    public Inventory()
    {
        InvType = InvType.Other;
        Type = InvType.ToString();
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class.
    /// </summary>
    /// <param name="productId"> the id of the product </param>
    /// <param name="warehouseId"> the id of the warehouse </param>
    /// <param name="minimumStock"> the minimum stock </param>
    /// <param name="currentStock"> the current stock </param>
    /// <param name="type"> the type of the inventory </param>
    public Inventory(int productId, int warehouseId, int minimumStock, int currentStock, string type)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        MinimumStock = minimumStock;
        CurrentStock = currentStock;
        try
        {
            InvType = Enum.Parse<InvType>(type);
            Type = type;
        }
        catch (Exception e)
        {
            throw new Exception("Invalid inventory type. Must be Medicine, Tools, Electronics, Food, Other");
        }
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
        try
        {
            InvType = Enum.Parse<InvType>(command.Type);
            Type = command.Type;
        }
        catch (Exception e)
        {
            throw new Exception("Invalid inventory type. Must be Medicine, Tools, Electronics, Food, Other");
        }
    }

    public void Update(UpdateInventoryCommand command)
    {
        ProductId = command.ProductId;
        WarehouseId = command.WarehouseId;
        MinimumStock = command.MinimumStock;
        CurrentStock = command.CurrentStock;
        try
        {
            InvType = Enum.Parse<InvType>(command.Type);
            Type = command.Type;
        }
        catch (Exception e)
        {
            throw new Exception("Invalid inventory type. Must be Medicine, Tools, Electronics, Food, Other");
        }
    }
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int MinimumStock { get; set; }
    public int CurrentStock { get; set; }
    
    public InvType InvType { get; set; }
    public string Type { get; set; }

}