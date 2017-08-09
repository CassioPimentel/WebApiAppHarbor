using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Conhecimento")]
    public class Conhecimento
    {
        public int ID { get; set; }

        [StringLength(80)]
        public string Titulo { get; set; }
    }
}