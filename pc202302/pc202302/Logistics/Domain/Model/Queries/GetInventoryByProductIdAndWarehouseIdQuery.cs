namespace pc202302.Logistics.Domain.Model.Queries;

public record GetInventoryByProductIdAndWarehouseIdQuery(int ProductId, int WarehouseId);