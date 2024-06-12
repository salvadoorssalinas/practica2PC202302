using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Shared.Domain.Repositories;

namespace pc202302.Logistics.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
    Task<Inventory?> FindByProductIdAndWarehouseIdAsync(int productId, int warehouseId);
}