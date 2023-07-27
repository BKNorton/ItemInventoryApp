using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemInventoryAPI.Models;
using ItemInventoryAPI.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ItemInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemInventoryContext _context;

        public ItemsController(ItemInventoryContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {
          if (_context.Items == null)
          {
              return NotFound();
          }

          return await _context.Items.Select(x => new ItemDTO
          {
              Id = x.Id,
              Name = x.Name,
              SerialNumber = x.SerialNumber,
              InInventory = x.InInventory,
          }).ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(Guid id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var itemDTO = await _context.Items
            .Where(x => x.Id == id)
            .Select(x => new ItemDTO
            {
                Id = x.Id,
                Name = x.Name,
                SerialNumber = x.SerialNumber,
                InInventory = x.InInventory,
            }).FirstOrDefaultAsync();

            if (itemDTO == null)
            {
                return NotFound();
            }

            return itemDTO;
        }

        // GET: api/Items/5
        [HttpGet("{id}/ItemHistory")]
        public async Task<ActionResult<List<Checkout>>> GetItemHistory(Guid id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.Include(i => i.Checkouts).Where(i => i.Id == id).FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return item.Checkouts;
        }




        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(Guid id, ItemDTO itemDTO)
        {
            if (id != itemDTO.Id)
            {
                return BadRequest();
            }
            var item = new Item { 
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                SerialNumber = itemDTO.SerialNumber,
                InInventory = itemDTO.InInventory
            };
            _context.Items.Attach(item);
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
          }

            var item = new Item
            {
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                SerialNumber = itemDTO.SerialNumber,
                InInventory = itemDTO.InInventory,
                Checkouts = new List<Checkout>()
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(Guid id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
