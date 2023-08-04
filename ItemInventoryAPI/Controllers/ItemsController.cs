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
        private  IItemRepository _repository;

        public ItemsController(IRepository<ItemDTO> repository)
        {
            _repository = (IItemRepository)repository;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>>? GetItems()
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

        // GET: api/Items/5
        [HttpGet("{id}/ItemHistory")]
        public async Task<ActionResult<List<Checkout>>> GetItemHistory(Guid id)
        {
            if (_repository.IsNull())
            {
                return NotFound();
            }

            var history = await _repository.GetItemHistory(id);

            if (history == null)
            {
                return NotFound();
            }

            return history;
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
            
            _repository.Update(itemDTO);
            await _repository.SaveChanges();

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
        {
            if (_repository.IsNull())
            {
                return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
            }

            await _repository.Add(itemDTO);
            await _repository.SaveChanges();

            return CreatedAtAction("GetItem", new { id = itemDTO.Id }, itemDTO);
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/Radio")]
        public async Task<ActionResult<Item>> PostRadio(RadioDTO radioDto)
        {
            if (_repository.IsNull())
            {
                return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
            }
            var radio = new ItemDTO
            {
                Id = radioDto.Id,
                Name = radioDto.Name,
                SerialNumber = radioDto.SerialNumber,
                InInventory = radioDto.InInventory         
            };
            _repository.Add(radio);
            await _repository.SaveChanges();

            return CreatedAtAction("GetItem", new { id = radio.Id }, radio);
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/Antenna")]
        public async Task<ActionResult<Item>> PostAntenna(AntennaDTO antennaDto)
        {
            if (_repository.IsNull())
            {
                return Problem("Entity set 'ItemInventoryContext.Items'  is null.");
            }
            var antenna = new ItemDTO
            {
                Id = antennaDto.Id,
                Name = antennaDto.Name,
                SerialNumber = antennaDto.SerialNumber,
                InInventory = antennaDto.InInventory,
            };
            _repository.Add(antenna);
            await _repository.SaveChanges();

            return CreatedAtAction("GetItem", new { id = antenna.Id }, antenna);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            if (_repository.IsNull())
            {
                return NotFound();
            }

            await _repository.Delete(id);
            await _repository.SaveChanges();

            return NoContent();
        }

        //private bool ItemExists(Guid id)
        //{
        //    return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
