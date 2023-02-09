namespace PindexBackend.Models {

    public class Office {

        //PK
        public int OfficeId { get; set; }

        //Per-office data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
