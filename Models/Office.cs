using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PindexBackend.Models {

    public class Office {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficeId { get; set; }

        //Per-office data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        
        [JsonIgnore]
        public Item? Item { get; set; }
    }
}
