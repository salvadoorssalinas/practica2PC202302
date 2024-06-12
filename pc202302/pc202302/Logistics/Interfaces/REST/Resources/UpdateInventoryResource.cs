namespace pc202302.Logistics.Interfaces.REST.Resources;

public record UpdateInventoryResource(int ProductId, int WarehouseId, int MinimumStock, int CurrentStock, string Type);