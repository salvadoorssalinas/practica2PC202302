using pc202302.Logistics.Domain.Model.Commands;
using pc202302.Logistics.Interfaces.REST.Resources;

namespace pc202302.Logistics.Interfaces.REST.Transform;

public static class UpdateInventoryCommandFromResourceAssembler
{
    public static UpdateInventoryCommand ToCommandFromResource(UpdateInventoryResource resource, int id)
    {
        return new UpdateInventoryCommand(id, resource.ProductId, resource.WarehouseId, resource.MinimumStock, resource.CurrentStock);
    }
}