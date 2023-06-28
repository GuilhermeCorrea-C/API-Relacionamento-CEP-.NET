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

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.Entity<ColaboradorModel>().HasMany(x => x.ListaDependentes).WithOne(x=>x.Colaborador).HasForeignKey(x => x.idColaborador).IsRequired(false);
            base.OnModelCreating(modelBuilder);


        }
    }
}