﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(SkeletonAppWebApiContext))]
    [Migration("20230831014054_InitialCreateMig")]
    partial class InitialCreateMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("IdDepFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreDep")
                        .HasColumnType("longtext");

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreGenero")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IdPersonaFk")
                        .HasColumnType("longtext");

                    b.Property<int>("IdSalonFk")
                        .HasColumnType("int");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.HasIndex("SalonId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext");

                    b.Property<int?>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("IdCiudadFk")
                        .HasColumnType("int");

                    b.Property<int>("IdGeneroFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPerFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int?>("TipoPersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TipoPersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreSalon")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Salones");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescripcionTipoPersona")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TipoPersonas");
                });

            modelBuilder.Entity("Dominio.Entities.TrainerSalon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IdPerTrainerFk")
                        .HasColumnType("longtext");

                    b.Property<int>("IdSalonFk")
                        .HasColumnType("int");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.HasIndex("SalonId");

                    b.ToTable("TrainerSalones");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("DepartamentoId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("Dominio.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("PaisId");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("Matriculas")
                        .HasForeignKey("PersonaId");

                    b.HasOne("Dominio.Entities.Salon", "Salon")
                        .WithMany("Matriculas")
                        .HasForeignKey("SalonId");

                    b.Navigation("Persona");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.Ciudad", "Ciudad")
                        .WithMany("Personas")
                        .HasForeignKey("CiudadId");

                    b.HasOne("Dominio.Entities.Genero", "Genero")
                        .WithMany("Personas")
                        .HasForeignKey("GeneroId");

                    b.HasOne("Dominio.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("TipoPersonaId");

                    b.Navigation("Ciudad");

                    b.Navigation("Genero");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Dominio.Entities.TrainerSalon", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("TrainerSalones")
                        .HasForeignKey("PersonaId");

                    b.HasOne("Dominio.Entities.Salon", "Salon")
                        .WithMany("TrainerSalones")
                        .HasForeignKey("SalonId");

                    b.Navigation("Persona");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entities.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("TrainerSalones");
                });

            modelBuilder.Entity("Dominio.Entities.Salon", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("TrainerSalones");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
