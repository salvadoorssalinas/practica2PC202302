using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Logistics.Domain.Model.Queries;
using pc202302.Logistics.Domain.Repositories;
using pc202302.Logistics.Domain.Services;
using pc202302.Shared.Domain.Repositories;

namespace pc202302.Logistics.Application.Internal.QueryServices;

public class InventoryQueryService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryQueryService
{
    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }

    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.InventoryId);
    }

    public async Task<Inventory?> Handle(GetInventoryByProductIdAndWarehouseIdQuery query)
    {
        return await inventoryRepository.FindByProductIdAndWarehouseIdAsync(query.ProductId, query.WarehouseId);
    }
}