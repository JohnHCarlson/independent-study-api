namespace PindexBackend.Models {
    public class Canorg {

        //PK
        public int CanorgId { get; set; }

        //Per-canorg data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
