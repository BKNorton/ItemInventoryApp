namespace ItemInventoryAPI.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SerialNumber { get; set; }
        public bool InInventory { get; set; }
        public List<Checkout> Checkouts { get; set; } = new List<Checkout>();
    }
}
