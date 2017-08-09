using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Empresa")]
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Senha { get; set; }
        public string Logo { get; set; }
    }
}