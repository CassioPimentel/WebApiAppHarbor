namespace WebAPIappHabor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Proposta")]
    public partial class Proposta
    {
        public int ID { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Mensagem { get; set; }

        public float? valor { get; set; }

        public int? Empresa_ID { get; set; }

        public int? Profissional_ID { get; set; }

        public bool? Status { get; set; }

        public bool? Visualizado { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Profissional Profissional { get; set; }
    }
}
