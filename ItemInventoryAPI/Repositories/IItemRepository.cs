using ItemInventory.API.DTOModels;
using ItemInventory.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemInventory.API.Repositories
{
    public interface IItemRepository : IRepository<ItemDTO>
    {
        public Task<ActionResult<List<Checkout>>> GetItemHistory(Guid id);
        public Task<ActionResult<List<Item>>> GetCheckedoutItems();
    }
}
