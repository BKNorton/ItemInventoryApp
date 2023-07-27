namespace ItemInventoryAPI.DTOModels
{
    public class AntennaDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SerialNumber { get; set; }
        public bool InInventory { get; set; }
        public bool HasAllParts { get; set; }
        public string Type { get; set; }
    }
}
