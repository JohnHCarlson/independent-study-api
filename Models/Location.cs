using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PindexBackend.Models {

    public class Location {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        //Per-location data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }

        [JsonIgnore]
        public Item? Item { get; set; }
    }
}

