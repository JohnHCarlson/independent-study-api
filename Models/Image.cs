using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PindexBackend.Models {
    public class Image {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        
        //Per-image data
        public DateTime UploadDate { get; set; }
        public required string FileName { get; set; }
    }
}
