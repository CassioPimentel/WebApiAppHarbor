namespace WebAPIappHabor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Profissional_Conhecimento")]
    public partial class Profissional_Conhecimento
    {
        public int ID { get; set; }

        public int? Conhecimento_ID { get; set; }

        public int? Profissional_ID { get; set; }

        public int? Nivel { get; set; }

        [StringLength(80)]
        public string Observacao { get; set; }

        public virtual Conhecimento Conhecimento { get; set; }

        public virtual Profissional Profissional { get; set; }
    }
}
