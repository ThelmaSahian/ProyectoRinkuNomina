﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RinkuNomina.Application;

#nullable disable

namespace RinkuNomina.Infrastructure.Migrations
{
    [DbContext(typeof(RinkuContext))]
    [Migration("20230528222212_add-table-RolEmpleado")]
    partial class addtableRolEmpleado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RinkuNomina.Domain.Model.RolEmpleado", b =>
                {
                    b.Property<Guid>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.HasKey("IdRol");

                    b.ToTable("RolEmpleado", (string)null);
                });

            modelBuilder.Entity("RinkuNominaDomain.Model.Empleado", b =>
                {
                    b.Property<Guid>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioModificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleado", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
