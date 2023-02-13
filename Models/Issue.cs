using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PindexBackend.Models {

    public class Issue {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IssueId { get; set; }

        //Per-issue data
        public required string Name { get; set; }

        //Many-to-many data
        [JsonIgnore]
        public ICollection<Item>? Items { get; set; }
    }
}

