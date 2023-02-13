using System.ComponentModel.DataAnnotations.Schema;

namespace PindexBackend.Models {
    public class Party {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartyId { get; set; }

        //Per-issue data
        public required string Name { get; set; }

        //Many-to-many data
        public ICollection<Item>? Items { get; set; }
    }
}
