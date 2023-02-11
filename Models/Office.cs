using System.ComponentModel.DataAnnotations.Schema;

namespace PindexBackend.Models {

    public class Office {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficeId { get; set; }

        //Per-office data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
