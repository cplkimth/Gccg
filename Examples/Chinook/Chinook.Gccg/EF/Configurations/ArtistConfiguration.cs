﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Chinook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Chinook.Data.Configurations
{
    public partial class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> entity)
        {
            entity.ToTable("Artist");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(120)
                .HasDefaultValue("");
            entity.Property(e => e.TypeCode).HasComment("[1]");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Artist> entity);
    }
}
