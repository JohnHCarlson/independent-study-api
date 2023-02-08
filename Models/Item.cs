namespace PindexBackend.Models {
    public class Item {
        public int ItemId { get; set; }

        public string? Location { get; set; }
        public DateTime? ElectionDate { get; set; }
        public int Quantity { get; set; }
        public bool? Won { get; set; }
        public string? StorageLocation { get; set; }
        public string? Notes { get; set; }

        public ICollection<Canorg> Canorgs { get; set; }
        public ICollection<Office> Offices { get; set; }

    }
}
