namespace PindexBackend.Models {
    public class Canorg {
        public int CanorgId { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
