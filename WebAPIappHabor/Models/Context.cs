using System.Data.Entity;

namespace WebAPIappHabor.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<Conhecimento> Conhecimento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Profissional_Conhecimento> Profissional_Conhecimento { get; set; }
        public DbSet<Proposta> Proposta { get; set; }
    }
}
