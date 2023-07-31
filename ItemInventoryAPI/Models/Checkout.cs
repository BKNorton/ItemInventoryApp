namespace ItemInventory.API.Models
{
    public class Checkout
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public DateTime DateCheckedout { get; set; }
        public DateTime DateReturned { get; set; }
        public string CheckedoutTo { get; set; } = string.Empty;
    }
}
