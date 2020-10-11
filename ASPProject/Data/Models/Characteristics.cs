namespace ASPProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Characteristics
    {
        public int CharacteristicsId { get; set; }
        public int Speed { get; set; }

        public int? Damage { get; set; }

        public int? Armor { get; set; }
        public virtual Hero Heroes { get; set; }
    }
}
