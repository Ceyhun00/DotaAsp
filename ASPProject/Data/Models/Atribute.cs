namespace ASPProject.Data.Models
{
    using ASPProject.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Atribute 
    {
        public int AtributeId { get; set; }

        [StringLength(200)]
        public string decs { get; set; }

        [Required]
        [StringLength(15)]
        public string AtributeName { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
