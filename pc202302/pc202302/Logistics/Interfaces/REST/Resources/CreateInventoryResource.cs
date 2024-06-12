namespace pc202302.Logistics.Interfaces.REST.Resources;

public record CreateInventoryResource(int ProductId, int WarehouseId, int MinimumStock, int CurrentStock, string Type);