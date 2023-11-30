﻿using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(u => u.Bio);
        builder.Property(u => u.Email);
        builder.Property(u => u.Image);
        builder.Property(u => u.PasswordHash);

        builder.Property(u => u.Slug)
           .IsRequired()
           .HasColumnType("VARCHAR")
           .HasMaxLength(80);

        builder.HasIndex(u => u.Slug, "IX_User_Slug")
            .IsUnique();
    }
}
