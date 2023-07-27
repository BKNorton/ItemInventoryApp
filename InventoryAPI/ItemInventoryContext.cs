using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI
{
    public class ItemInventoryContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }

        public string DbPath { get; }

        public ItemInventoryContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Inventory.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={DbPath}");
    }
}
