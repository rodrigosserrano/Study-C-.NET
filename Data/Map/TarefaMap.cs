﻿using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Map;

public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Descricao).HasMaxLength(1000);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.UsuarioId);

        builder.HasOne<UsuarioModel>(x => x.Usuario);
    }
}

