namespace WebAPIappHabor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Conhecimento")]
    public partial class Conhecimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conhecimento()
        {
            Profissional_Conhecimento = new HashSet<Profissional_Conhecimento>();
        }

        public int ID { get; set; }

        [StringLength(80)]
        public string Titulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profissional_Conhecimento> Profissional_Conhecimento { get; set; }
    }
}
