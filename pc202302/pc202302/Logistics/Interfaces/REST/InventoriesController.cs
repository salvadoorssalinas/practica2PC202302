using Microsoft.AspNetCore.Mvc;
using pc202302.Logistics.Domain.Model.Commands;
using pc202302.Logistics.Domain.Model.Queries;
using pc202302.Logistics.Domain.Services;
using pc202302.Logistics.Interfaces.REST.Resources;
using pc202302.Logistics.Interfaces.REST.Transform;

namespace pc202302.Logistics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InventoriesController(IInventoryCommandService inventoryCommandService, IInventoryQueryService inventoryQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryResource createInventoryResource)
    {
        try
        {
            var existingInventory = await inventoryQueryService.Handle(new GetInventoryByProductIdAndWarehouseIdQuery(createInventoryResource.ProductId, createInventoryResource.WarehouseId));
            if (existingInventory != null) return BadRequest(new { message = "There's another inventory with the same Product Id and Warehouse Id" });

            var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(createInventoryResource);
            var inventory = await inventoryCommandService.Handle(createInventoryCommand);
            if (inventory == null) return BadRequest();
            var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.Id }, resource);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the inventory. " + e.Message });
        }
        
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryResource updateInventoryResource, [FromRoute] int id)
    {
        try
        {
            var existingInventory = await inventoryQueryService.Handle(new GetInventoryByProductIdAndWarehouseIdQuery(updateInventoryResource.ProductId, updateInventoryResource.WarehouseId));
            if (existingInventory != null && existingInventory.Id != id) return BadRequest(new { message = "There's another inventory with the same Product Id and Warehouse Id" });

            var updateInventoryCommand = UpdateInventoryCommandFromResourceAssembler.ToCommandFromResource(updateInventoryResource, id);
            var inventory = await inventoryCommandService.Handle(updateInventoryCommand);
            if (inventory == null) return BadRequest();
            var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
            return Ok(resource);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the inventory. " + e.Message });
        }
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllInventories()
    {
        var getAllInventoriesQuery = new GetAllInventoriesQuery();
        var inventories = await inventoryQueryService.Handle(getAllInventoriesQuery);
        var resources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetInventoryById(int id)
    {
        var inventory = await inventoryQueryService.Handle(new GetInventoryByIdQuery(id));
        if (inventory == null) return NotFound();
        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(resource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInventory(int id)
    {
        var deleteInventoryCommand = new DeleteInventoryCommand(id);
        var inventory = await inventoryCommandService.Handle(deleteInventoryCommand);
        if (inventory == null) return NotFound();
        return NoContent();
    }
    
}