namespace PindexBackend.Models {
    public class Office {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
