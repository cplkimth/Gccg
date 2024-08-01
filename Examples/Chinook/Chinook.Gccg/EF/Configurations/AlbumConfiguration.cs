﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Chinook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Chinook.Data.Configurations
{
    public partial class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity.ToTable("Album");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(160)
                .HasDefaultValue("");
            entity.Property(e => e.TypeCode).HasComment("[2]");

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums).HasForeignKey(d => d.ArtistId);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Album> entity);
    }
}
