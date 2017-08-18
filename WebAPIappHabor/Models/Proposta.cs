namespace WebAPIappHabor.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Proposta")]
    public partial class Proposta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Mensagem { get; set; }

        public float? valor { get; set; }

        public int? Empresa_ID { get; set; }

        public int? Profissional_ID { get; set; }

        public bool? Status { get; set; }

        public bool? Visualizado { get; set; }

        [JsonIgnore]
        public virtual Empresa Empresa { get; set; }

        [JsonIgnore]
        public virtual Profissional Profissional { get; set; }
    }
}
