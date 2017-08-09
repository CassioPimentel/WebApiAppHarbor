using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Profissional_Conhecimento")]
    public class Profissional_Conhecimento
    {
        public int Id { get; set; }
        public int Conhecimento_ID { get; set; }
        public int Profissional_ID { get; set; }
        public int Nivel { get; set; }
        public string Observacao { get; set; }

        public virtual Profissional Profissional { get; set; }
        public virtual Conhecimento Conhecimento { get; set; }
    }
}