using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIappHabor.Models
{
    [Table("dbfe08b01ebb344c598f92a7c800c6b3d6.Profissional")]
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Avatar { get; set; }
        public float PretensaoSalarial { get; set; }
    }
}