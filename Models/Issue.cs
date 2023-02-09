namespace PindexBackend.Models {

    public class Issue {

        //PK
        public int IssueId { get; set; }

        //Per-issue data
        public required string Name { get; set; }

        //Many-to-many data
        public ICollection<Item> Items { get; set; }
    }
}

