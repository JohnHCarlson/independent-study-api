using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PindexBackend.Models {

    public class Categorization {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorizationId { get; set; }

        //Per-categorization data
        public required string Name { get; set; }

        //Many-to-many data
        [JsonIgnore]
        public ICollection<Item>? Items { get; set; }
    }
}

