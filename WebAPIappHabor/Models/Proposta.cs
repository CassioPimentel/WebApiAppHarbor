using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Proposta")]
    public class Proposta
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public float Valor { get; set; }
        public int Empresa_ID { get; set; }
        public int Profissional_ID { get; set; }
        public bool Status { get; set; }
        public bool Visualizado { get; set; }
    }
}