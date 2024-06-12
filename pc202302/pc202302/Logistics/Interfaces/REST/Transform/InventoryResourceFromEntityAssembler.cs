using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Logistics.Interfaces.REST.Resources;

namespace pc202302.Logistics.Interfaces.REST.Transform;

public static class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Inventory entity)
    {
        return new InventoryResource(entity.Id, entity.ProductId, entity.WarehouseId, entity.MinimumStock, entity.CurrentStock);
    }
}