﻿// <auto-generated />
using System;
using ChatonsBDD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatonsBDD.Migrations
{
    [DbContext(typeof(ContexteBDD))]
    [Migration("20210211101635_AjoutChaton")]
    partial class AjoutChaton
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ChatonsBDD.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ChatonsBDD.Models.Chaton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnneeDeNaissance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategorieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Chaton");
                });

            modelBuilder.Entity("ChatonsBDD.Models.Chaton", b =>
                {
                    b.HasOne("ChatonsBDD.Models.Categorie", "Categorie")
                        .WithMany("Chatons")
                        .HasForeignKey("CategorieId");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("ChatonsBDD.Models.Categorie", b =>
                {
                    b.Navigation("Chatons");
                });
#pragma warning restore 612, 618
        }
    }
}
