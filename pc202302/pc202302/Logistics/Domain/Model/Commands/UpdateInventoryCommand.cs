namespace pc202302.Logistics.Domain.Model.Commands;

public record UpdateInventoryCommand(int InventoryId, int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);