using pc202302.Logistics.Domain.Model.Aggregates;
using pc202302.Logistics.Domain.Model.Commands;
using pc202302.Logistics.Domain.Repositories;
using pc202302.Logistics.Domain.Services;
using pc202302.Shared.Domain.Repositories;

namespace pc202302.Logistics.Application.Internal.CommandServices;

public class InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryCommandService
{
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        // validation of minimum stock
        if (command.MinimumStock < 1)
        {
            throw new Exception("Minimum stock must be equal or greater than 1");
        }
        
        // validation of current stock
        if (command.CurrentStock < command.MinimumStock)
        {
            throw new Exception("Current stock must be equal or greater than Minimum stock");
        }

        try
        {
            var inventory = new Inventory(command.ProductId, command.WarehouseId, command.MinimumStock, command.CurrentStock);
            await inventoryRepository.AddAsync(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Inventory?> Handle(UpdateInventoryCommand command)
    {
        // validation of minimum stock
        if (command.MinimumStock < 1)
        {
            throw new Exception("Minimum stock must be equal or greater than 1");
        }
        
        // validation of current stock
        if (command.CurrentStock < command.MinimumStock)
        {
            throw new Exception("Current stock must be equal or greater than Minimum stock");
        }
        
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory == null)
        {
            throw new Exception("Inventory not found");
        }
        
        // update inventory
        inventory.ProductId = command.ProductId;
        inventory.WarehouseId = command.WarehouseId;
        inventory.MinimumStock = command.MinimumStock;
        inventory.CurrentStock = command.CurrentStock;
        await unitOfWork.CompleteAsync();
        return inventory;
    }

    public async Task<Inventory?> Handle(DeleteInventoryCommand command)
    {
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory == null)
        {
            throw new Exception("Inventory not found");
        }
        
        // delete inventory
        inventoryRepository.Remove(inventory);
        await unitOfWork.CompleteAsync();
        return inventory;
    }
    
}