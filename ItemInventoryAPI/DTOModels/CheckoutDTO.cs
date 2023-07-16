
namespace ItemInventoryAPI.ModelsDTO
{
    public class CheckoutDTO
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public DateTime DateCheckedout { get; set; }
        public DateTime DateReturned { get; set; }
        public string CheckedoutTo { get; set; } = string.Empty;
    }
}
