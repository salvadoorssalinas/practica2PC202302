using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Logistics.Domain.Model.Queries;

namespace pc202302.Logistics.Domain.Services;

public interface IInventoryQueryService
{
    Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query);
    Task<Inventory?> Handle(GetInventoryByIdQuery query);
    Task<Inventory?> Handle(GetInventoryByProductIdAndWarehouseIdQuery query);
}