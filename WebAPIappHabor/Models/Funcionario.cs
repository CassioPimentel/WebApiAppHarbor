using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Funcionario")]
    public class Funcionario
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}