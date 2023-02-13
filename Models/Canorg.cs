using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PindexBackend.Models {
    public class Canorg {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CanorgId { get; set; }

        //Per-canorg data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        
        [JsonIgnore]
        public Item? Item { get; set; }
    }
}
