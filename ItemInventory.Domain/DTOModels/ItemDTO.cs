namespace ItemInventoryAPI.DTOModels
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SerialNumber { get; set; }
        public bool InInventory { get; set; }
    }
}
