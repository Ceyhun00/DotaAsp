namespace ASPProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Clothes
    {
        public int ClothesId { get; set; }
        [StringLength(15)]
        public string Head { get; set; }

        [StringLength(15)]
        public string Body { get; set; }
        [StringLength(15)]
        public string Legs { get; set; }
        public virtual Hero Heroes { get; set; }
    }
}
