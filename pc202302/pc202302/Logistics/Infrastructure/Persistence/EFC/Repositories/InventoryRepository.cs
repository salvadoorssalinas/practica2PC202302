using Microsoft.EntityFrameworkCore;
using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Logistics.Domain.Repositories;
using pc202302.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc202302.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc202302.Logistics.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context) : BaseRepository<Inventory>(context), IInventoryRepository
{
    public async Task<Inventory?> FindByProductIdAndWarehouseIdAsync(int productId, int warehouseId)
    {
        return await context.Inventories
            .Where(i => i.ProductId == productId && i.WarehouseId == warehouseId)
            .FirstOrDefaultAsync();
    }
    
}