namespace ItemInventoryAPI.DTOModels
{
    public class RadioDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public bool InInventory { get; set; }
        public bool HasBattery { get; set; }
    }
}
