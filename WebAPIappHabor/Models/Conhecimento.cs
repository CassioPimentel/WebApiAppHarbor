using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Conhecimento")]
    public class Conhecimento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}