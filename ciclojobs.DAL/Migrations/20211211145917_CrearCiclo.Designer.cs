﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ciclojobs.DAL.Entities;

namespace ciclojobs.DAL.Migrations
{
    [DbContext(typeof(ciclojobsContext))]
    [Migration("20211211145917_CrearCiclo")]
    partial class CrearCiclo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ciclojobs.DAL.Entities.Alumno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .HasColumnType("longtext");

                    b.Property<double>("calificacion_media")
                        .HasColumnType("double");

                    b.Property<string>("contrasena")
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fechanacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("foto")
                        .HasColumnType("longtext");

                    b.Property<int>("id_ciclo")
                        .HasColumnType("int");

                    b.Property<int>("idprovincias")
                        .HasColumnType("int");

                    b.Property<string>("localidad")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("id_ciclo");

                    b.HasIndex("idprovincias");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ciclo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("idfamiliaprofe")
                        .HasColumnType("int");

                    b.Property<int>("idtipo")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("idfamiliaprofe");

                    b.HasIndex("idtipo");

                    b.ToTable("Ciclo");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ciclo_Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("idCiclo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfertaId");

                    b.HasIndex("idCiclo");

                    b.ToTable("Ciclo_Oferta");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Empresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("contrasena")
                        .HasColumnType("longtext");

                    b.Property<string>("direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<int>("idprovincias")
                        .HasColumnType("int");

                    b.Property<string>("localidad")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("idprovincias");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.FamiliaProfe", b =>
                {
                    b.Property<int>("idprofe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("idprofe");

                    b.ToTable("FamiliaProfe");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Inscripciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("idAlumno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfertaId");

                    b.HasIndex("idAlumno");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ofertas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Horario")
                        .HasColumnType("longtext");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fecha_fin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fecha_inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idempresas")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<double>("remuneracion")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("idempresas");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Provincias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("provincias")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.TipoCiclo", b =>
                {
                    b.Property<int>("idtipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("idtipo");

                    b.ToTable("TipoCiclo");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Alumno", b =>
                {
                    b.HasOne("ciclojobs.DAL.Entities.Ciclo", "ciclo")
                        .WithMany()
                        .HasForeignKey("id_ciclo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ciclojobs.DAL.Entities.Provincias", "provincia")
                        .WithMany()
                        .HasForeignKey("idprovincias")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ciclo");

                    b.Navigation("provincia");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ciclo", b =>
                {
                    b.HasOne("ciclojobs.DAL.Entities.FamiliaProfe", "familia")
                        .WithMany()
                        .HasForeignKey("idfamiliaprofe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ciclojobs.DAL.Entities.TipoCiclo", "TipoCiclo")
                        .WithMany()
                        .HasForeignKey("idtipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("familia");

                    b.Navigation("TipoCiclo");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ciclo_Oferta", b =>
                {
                    b.HasOne("ciclojobs.DAL.Entities.Ofertas", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ciclojobs.DAL.Entities.Ciclo", "ciclo")
                        .WithMany("ciclo_oferta")
                        .HasForeignKey("idCiclo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ciclo");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Empresa", b =>
                {
                    b.HasOne("ciclojobs.DAL.Entities.Provincias", "provincias")
                        .WithMany()
                        .HasForeignKey("idprovincias")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("provincias");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Inscripciones", b =>
                {
                    b.HasOne("ciclojobs.DAL.Entities.Ofertas", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ciclojobs.DAL.Entities.Alumno", "Alumno")
                        .WithMany("inscripciones")
                        .HasForeignKey("idAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ofertas", b =>
                {
                    b.HasOne("ciclojobs.DAL.Entities.Empresa", "empresas")
                        .WithMany()
                        .HasForeignKey("idempresas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("empresas");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Alumno", b =>
                {
                    b.Navigation("inscripciones");
                });

            modelBuilder.Entity("ciclojobs.DAL.Entities.Ciclo", b =>
                {
                    b.Navigation("ciclo_oferta");
                });
#pragma warning restore 612, 618
        }
    }
}
