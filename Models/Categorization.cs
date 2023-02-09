namespace PindexBackend.Models {

    public class Categorization {

        //PK
        public int CategorizationId { get; set; }

        //Per-categorization data
        public string Name { get; set; }

        //Many-to-many data
        public ICollection<Item> Items;
    }
}

