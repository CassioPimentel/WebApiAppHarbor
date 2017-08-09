using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Profissional")]
    public class Profissional
    {
        public int ID { get; set; }

        [StringLength(40)]
        public string Nome { get; set; }

        [StringLength(60)]
        public string SobreNome { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        [StringLength(40)]
        public string Senha { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Avatar { get; set; }

        public float? PretensaoSalarial { get; set; }
    }
}