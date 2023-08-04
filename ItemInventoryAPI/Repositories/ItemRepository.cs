
using ItemInventory.API.DTOModels;
using ItemInventory.API.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ItemInventory.API.Repositories
{
    public class ItemRepository : GenericRepository<ItemDTO>, IItemRepository
    {
        public ItemRepository(ItemInventoryContext context) : base(context)
        {
        }

        public async override Task<ActionResult<IEnumerable<ItemDTO>>>? GetAll()
        {
            return await _context.Set<Item>()
                .AsQueryable()
                .Include("Checkouts")
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
                .Include("Checkouts")
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

        public async Task<ActionResult<List<Checkout>>> GetItemHistory(Guid id)
        {
            var item = await _context.Set<Item>()
                .Include("Checkouts")
                .AsQueryable()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (item == null) return new NotFoundResult();

            return item.Checkouts.Take(10).ToList();
        }

        public async Task<ActionResult<List<Item>>> GetCheckedoutItems()
        {
            var items = await _context.Set<Item>()
                .Include("Checkouts")
                .AsQueryable()
                .Where(i => i.InInventory == false)
                .ToListAsync();

            if (items == null) return new NotFoundResult();

            return items;
        }

        public async override Task<ActionResult<ItemDTO>> Add(ItemDTO item)
        {
            var newItem = new Item()
            { 
                //Id = item.Id,
                Name = item.Name,
                SerialNumber = item.SerialNumber,
                InInventory = item.InInventory
            };
            return new OkObjectResult(await _context.AddAsync(newItem));
        }

        public async override Task<IActionResult> Update(ItemDTO itemDTO)
        {
            var item = new Item()
            { 
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                SerialNumber = itemDTO.SerialNumber,
                InInventory = itemDTO.InInventory
            };
            return new OkObjectResult(_context.Update(item));

        }

        public async override Task<ActionResult> Delete(Guid id)
        {
            var item = await _context.Set<Item>().FindAsync(id);
            if (item == null)
            {
                return new NotFoundObjectResult(item);
            }
            _context.Remove(item);
            return await SaveChanges();
        }
    }
}
