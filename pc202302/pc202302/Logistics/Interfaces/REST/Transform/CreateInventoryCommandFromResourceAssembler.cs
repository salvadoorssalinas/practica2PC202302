using pc202302.Logistics.Domain.Model.Commands;
using pc202302.Logistics.Interfaces.REST.Resources;

namespace pc202302.Logistics.Interfaces.REST.Transform;

public static class CreateInventoryCommandFromResourceAssembler
{
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(resource.ProductId, resource.WarehouseId, resource.MinimumStock, resource.CurrentStock, resource.Type);
    }
}