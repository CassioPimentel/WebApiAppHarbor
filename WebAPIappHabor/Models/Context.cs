namespace WebAPIappHabor.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Conhecimento> Conhecimento { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Profissional> Profissional { get; set; }
        public virtual DbSet<Profissional_Conhecimento> Profissional_Conhecimento { get; set; }
        public virtual DbSet<Proposta> Proposta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conhecimento>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Conhecimento>()
                .HasMany(e => e.Profissional_Conhecimento)
                .WithOptional(e => e.Conhecimento)
                .HasForeignKey(e => e.Conhecimento_ID);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.CNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Proposta)
                .WithOptional(e => e.Empresa)
                .HasForeignKey(e => e.Empresa_ID);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.SobreNome)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Profissional>()
                .HasMany(e => e.Profissional_Conhecimento)
                .WithOptional(e => e.Profissional)
                .HasForeignKey(e => e.Profissional_ID);

            modelBuilder.Entity<Profissional>()
                .HasMany(e => e.Proposta)
                .WithOptional(e => e.Profissional)
                .HasForeignKey(e => e.Profissional_ID);

            modelBuilder.Entity<Profissional_Conhecimento>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Proposta>()
                .Property(e => e.Mensagem)
                .IsUnicode(false);
        }
    }
}
