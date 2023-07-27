using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemInventoryAPI;
using ItemInventoryAPI.Models;

namespace ItemInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        private readonly ItemInventoryContext _context;

        public CheckoutsController(ItemInventoryContext context)
        {
            _context = context;
        }

        // GET: api/Checkouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkout>>> GetCheckouts()
        {
          if (_context.Checkouts == null)
          {
              return NotFound();
          }
            return await _context.Checkouts.ToListAsync();
        }

        // GET: api/Checkouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkout>> GetCheckout(Guid id)
        {
          if (_context.Checkouts == null)
          {
              return NotFound();
          }
            var checkout = await _context.Checkouts.FindAsync(id);

            if (checkout == null)
            {
                return NotFound();
            }

            return checkout;
        }

        // PUT: api/Checkouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckout(Guid id, Checkout checkout)
        {
            if (id != checkout.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckoutExists(id))
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

        // POST: api/Checkouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Checkout>> PostCheckout(Checkout checkout)
        {
          if (_context.Checkouts == null)
          {
              return Problem("Entity set 'ItemInventoryContext.Checkouts'  is null.");
          }
            _context.Checkouts.Add(checkout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckout", new { id = checkout.Id }, checkout);
        }

        // DELETE: api/Checkouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckout(Guid id)
        {
            if (_context.Checkouts == null)
            {
                return NotFound();
            }
            var checkout = await _context.Checkouts.FindAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }

            _context.Checkouts.Remove(checkout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckoutExists(Guid id)
        {
            return (_context.Checkouts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
