namespace ItemInventory.API.Models
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
