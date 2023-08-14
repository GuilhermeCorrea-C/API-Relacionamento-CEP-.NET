using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Data.Map;
using APIRelacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRelacionamento.Data
{
    public class SistemaConsultasDBContext : DbContext
    {
        public SistemaConsultasDBContext(DbContextOptions<SistemaConsultasDBContext> options):base(options)
        {

        }
        
        public DbSet<DependenteModel> Dependentes { get; set; }
        public DbSet<ColaboradorModel> Colaboradores { get; set; }

        public DbSet<ViaCepModel> InfoCep { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.Entity<ColaboradorModel>().HasMany(x => x.ListaDependentes).WithOne(x=>x.Colaborador).HasForeignKey(x => x.ColaboradorId).IsRequired();
            modelBuilder.Entity<ViaCepModel>(entity => {
                entity.HasKey(x => x.Cep);
                
                entity.Property(e => e.Logradouro).HasColumnName("Logradouro");
                entity.Property(e => e.Complemento).HasColumnName("Complemento");
                entity.Property(e => e.Bairro).HasColumnName("Bairro");
                entity.Property(e => e.Localidade).HasColumnName("Localidade");
                entity.Property(e => e.Uf).HasColumnName("Uf");
                entity.Property(e => e.Ibge).HasColumnName("Ibge");
                entity.Property(e => e.Gia).HasColumnName("Gia");
                entity.Property(e => e.DDD).HasColumnName("DDD");
                entity.Property(e => e.Siafi).HasColumnName("Siafi");
            });
          modelBuilder.Entity<ColaboradorModel>().HasOne(x => x.ViaCep).WithMany(i => i.Colaboradores).HasForeignKey(c => c.CepColaborador).HasPrincipalKey(x => x.Cep);
            base.OnModelCreating(modelBuilder);
        }
    }
}