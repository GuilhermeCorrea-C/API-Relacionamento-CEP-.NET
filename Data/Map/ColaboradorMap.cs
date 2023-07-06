using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIRelacionamento.Data.Map
{
    public class ColaboradorMap : IEntityTypeConfiguration<ColaboradorModel>
    {
        public void Configure(EntityTypeBuilder<ColaboradorModel> builder)
        {
            builder.HasKey(x => x.idColaborador);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.salario).IsRequired();
        }
    }
}