namespace ItemInventoryAPI.Models
{
    public class Radio : Item
    {
        public bool HasBattery { get; set; }

        public Radio()
        {
            Name = "Radio";
        }
    }
}
