
using ItemInventory.API.DTOModels;
using ItemInventory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ItemInventory.API.Repositories
{
    public class ItemRepository : GenericRepository<ItemDTO>
    {
        public ItemRepository(ItemInventoryContext context) : base(context)
        {
        }

        public async override Task<ActionResult<IEnumerable<ItemDTO>>>? GetAll()
        {
            return await _context.Set<Item>()
                .AsQueryable()
                .Select(i => new ItemDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    SerialNumber = i.SerialNumber,
                    InInventory = i.InInventory
                })
                .ToListAsync();

        }

        public async override Task<ActionResult<ItemDTO>>? Get(Guid id)
        {
            var item = await _context.Set<Item>()
                .AsQueryable()
                .Select(i => new ItemDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    SerialNumber = i.SerialNumber,
                    InInventory = i.InInventory
                })
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            return item;
        }
    }
}
