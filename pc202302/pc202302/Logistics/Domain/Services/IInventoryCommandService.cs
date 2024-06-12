using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Logistics.Domain.Model.Commands;

namespace pc202302.Logistics.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand command);
    Task<Inventory?> Handle(UpdateInventoryCommand command);
    Task<Inventory?> Handle(DeleteInventoryCommand command);
}