﻿// <auto-generated />
using System;
using FIAP.GlobalSolution.EcoSynergy.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241122002215_AddRelationship")]
    partial class AddRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.DadoSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeSensor")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ProducaoEnergiaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<double>("ValorLuminosidade")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("Id");

                    b.HasIndex("ProducaoEnergiaId")
                        .IsUnique();

                    b.ToTable("DadosSensor");
                });

            modelBuilder.Entity("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.Painel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("ProducaoEnergiaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("ProducaoMedia")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("Id");

                    b.HasIndex("ProducaoEnergiaId");

                    b.ToTable("Paineis");
                });

            modelBuilder.Entity("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.ProducaoEnergia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("PotenciaGerada")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("TemperaturaAmbiente")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("ProducoesEnergia");
                });

            modelBuilder.Entity("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.DadoSensor", b =>
                {
                    b.HasOne("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.ProducaoEnergia", null)
                        .WithOne("DadosLuminosidade")
                        .HasForeignKey("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.DadoSensor", "ProducaoEnergiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.Painel", b =>
                {
                    b.HasOne("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.ProducaoEnergia", null)
                        .WithMany("Paineis")
                        .HasForeignKey("ProducaoEnergiaId");
                });

            modelBuilder.Entity("FIAP.GlobalSolution.EcoSynergy.Domain.Entities.ProducaoEnergia", b =>
                {
                    b.Navigation("DadosLuminosidade")
                        .IsRequired();

                    b.Navigation("Paineis");
                });
#pragma warning restore 612, 618
        }
    }
}