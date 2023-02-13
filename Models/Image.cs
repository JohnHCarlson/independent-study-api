using System.ComponentModel.DataAnnotations.Schema;

namespace PindexBackend.Models {
    public class Image {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        
        //Per-image data
        public DateTime UploadDate { get; set; }
        public required string FileName { get; set; }
        
        //One-to-one data
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
