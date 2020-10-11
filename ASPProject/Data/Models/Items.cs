namespace ASPProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Items
    {
        public int ItemsId { get; set; }

        [StringLength(15)]
        public string First_item { get; set; }

        [StringLength(15)]
        public string Second_item { get; set; }

        [StringLength(15)]
        public string Third_item { get; set; }

        [StringLength(15)]
        public string Forth_item { get; set; }

        [StringLength(15)]
        public string Fifth_item { get; set; }

        [StringLength(15)]
        public string Sixth_item { get; set; }

        public virtual Hero Heroes { get; set; }
    }
}

