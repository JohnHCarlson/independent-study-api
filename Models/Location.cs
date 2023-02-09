namespace PindexBackend.Models {

    public class Location {

        //PK
        public int LocationId { get; set; }

        //Per-location data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}

