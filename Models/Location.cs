﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PindexBackend.Models {

    public class Location {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        //Per-location data
        public required string Name { get; set; }

        //Many-to-one data
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}

