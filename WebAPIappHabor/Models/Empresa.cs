namespace WebAPIappHabor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Empresa")]
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            Proposta = new HashSet<Proposta>();
        }

        public int ID { get; set; }

        [StringLength(80)]
        public string Nome { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        [StringLength(20)]
        public string CNPJ { get; set; }

        [StringLength(50)]
        public string senha { get; set; }

        [Column(TypeName = "char")]
        [StringLength(255)]
        public string Logo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proposta> Proposta { get; set; }
    }
}
