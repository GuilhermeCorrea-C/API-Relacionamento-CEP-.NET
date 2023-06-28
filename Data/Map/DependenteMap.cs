using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIRelacionamento.Data.Map
{
    public class DependenteMap  : IEntityTypeConfiguration<DependenteModel>
    {
        public void Configure(EntityTypeBuilder<DependenteModel> builder)
        {
            builder.HasKey(x => x.idDependente);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.sobrenome).IsRequired().HasMaxLength(100);  
        }
    }
}