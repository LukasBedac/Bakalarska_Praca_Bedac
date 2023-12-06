﻿// <auto-generated />
using System;
using FRI_Quiz_Bakalarska_Praca.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FRI_Quiz_Bakalarska_Praca.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231204141402_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Kviz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DatumDo")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DatumOd")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nazov")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Popis")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Kvizy");
                });

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Odpoved", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OtazkaId")
                        .HasColumnType("int");

                    b.Property<int>("Poradie")
                        .HasColumnType("int");

                    b.Property<bool>("Spravna")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("OtazkaId");

                    b.ToTable("Odpoved");
                });

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Otazka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("KvizId")
                        .HasColumnType("int");

                    b.Property<string>("Nazov")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Poradie")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("KvizId");

                    b.ToTable("Otazka");
                });

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Odpoved", b =>
                {
                    b.HasOne("FRI_Quiz_Bakalarska_Praca.Data.Model.Otazka", null)
                        .WithMany("Odpovede")
                        .HasForeignKey("OtazkaId");
                });

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Otazka", b =>
                {
                    b.HasOne("FRI_Quiz_Bakalarska_Praca.Data.Model.Kviz", null)
                        .WithMany("Otazky")
                        .HasForeignKey("KvizId");
                });

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Kviz", b =>
                {
                    b.Navigation("Otazky");
                });

            modelBuilder.Entity("FRI_Quiz_Bakalarska_Praca.Data.Model.Otazka", b =>
                {
                    b.Navigation("Odpovede");
                });
#pragma warning restore 612, 618
        }
    }
}