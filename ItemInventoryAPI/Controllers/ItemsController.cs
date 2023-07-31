using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemInventory.API.DTOModels;
using ItemInventory.API.Models;
using ItemInventory.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ItemInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<ItemDTO> _repository;

        public ItemsController(IRepository<ItemDTO> repository)
        {
            _repository = repository;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {
          if (_repository.IsNull())
          {
              return NotFound();
          }

          return await _repository.GetAll();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>>? GetItem(Guid id)
        {
            if (_repository.IsNull())
            {
                return NotFound();
            }
            var item = await _repository.Get(id);
            if (item == null) return NotFound();
            else return item;
        }

        //// GET: api/Items/5
        //[HttpGet("{id}/ItemHistory")]
        //public async Task<ActionResult<List<Checkout>>> GetItemHistory(Guid id)
        //{
        //    if (_repository.IsNull())
        //    {
        //        return NotFound();
        //    }
        //    var item = await _context.Items.Include(i => i.Checkouts).Where(i => i.Id == id).FirstOrDefaultAsync();

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return item.Checkouts;
        //}




        //        // PUT: api/Items/5
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutItem(Guid id, ItemDTO itemDTO)
        //        {
        //            if (id != itemDTO.Id)
        //            {
        //                return BadRequest();
        //            }
        //            var item = new Item { 
        //                Id = itemDTO.Id,
        //                Name = itemDTO.Name,
        //                SerialNumber = itemDTO.SerialNumber,
        //                InInventory = itemDTO.InInventory
        //            };
        //            _context.Items.Attach(item);
        //            _context.Entry(item).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!ItemExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/Items
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost]
        //        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
        //        {
        //          if (_context.Items == null)
        //          {
        //              return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
        //          }

        //            var item = new Item
        //            {
        //                Id = itemDTO.Id,
        //                Name = itemDTO.Name,
        //                SerialNumber = itemDTO.SerialNumber,
        //                InInventory = itemDTO.InInventory,
        //                Checkouts = new List<Checkout>()
        //            };

        //            _context.Items.Add(item);
        //            await _context.SaveChangesAsync();

        //            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        //        }

        //        // POST: api/Items
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost("/api/Radio")]
        //        public async Task<ActionResult<Item>> PostRadio(RadioDTO radioDto)
        //        {
        //            if (_context.Items == null)
        //            {
        //                return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
        //            }
        //            var radio = new Radio
        //            {
        //                Id = radioDto.Id,
        //                Name = radioDto.Name,
        //                SerialNumber = radioDto.SerialNumber,
        //                InInventory = radioDto.InInventory,
        //                HasBattery = radioDto.HasBattery
        //            };
        //            _context.Items.Add(radio);
        //            await _context.SaveChangesAsync();

        //            return CreatedAtAction("GetItem", new { id = radio.Id }, radio);
        //        }

        //        // POST: api/Items
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost("/api/Antenna")]
        //        public async Task<ActionResult<Item>> PostAntenna(AntennaDTO antennaDto)
        //        {
        //            if (_context.Items == null)
        //            {
        //                return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
        //            }
        //            var antenna = new Antenna
        //            {
        //                Id = antennaDto.Id,
        //                Name = antennaDto.Name,
        //                SerialNumber = antennaDto.SerialNumber,
        //                InInventory = antennaDto.InInventory,
        //                HasAllParts = antennaDto.HasAllParts,
        //            };
        //            _context.Items.Add(antenna);
        //            await _context.SaveChangesAsync();

        //            return CreatedAtAction("GetItem", new { id = antenna.Id }, antenna);
        //        }

        //        // DELETE: api/Items/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteItem(Guid id)
        //        {
        //            if (_context.Items == null)
        //            {
        //                return NotFound();
        //            }
        //            var item = await _context.Items.FindAsync(id);
        //            if (item == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Items.Remove(item);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool ItemExists(Guid id)
        //        {
        //            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        //        }
    }
}
