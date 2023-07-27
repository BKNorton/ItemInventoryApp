namespace ItemInventoryAPI.Models
{
    public class Checkout
    {
        public Guid Id { get; set; }
        //public Item Item { get; set; } = new Item();
        public Guid ItemId { get; set; }
        public DateTime DateCheckedout { get; set; }
        public DateTime DateReturned { get; set; }
        public string CheckedoutTo { get; set; } = string.Empty;
    }
}
