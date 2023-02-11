﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PindexBackend.Models {

    public class Categorization {

        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorizationId { get; set; }

        //Per-categorization data
        public string Name { get; set; }

        //Many-to-many data
        public ICollection<Item> Items;
    }
}

