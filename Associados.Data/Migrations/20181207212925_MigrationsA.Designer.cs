﻿// <auto-generated />
using System;
using Associados.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Associados.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181207212925_MigrationsA")]
    partial class MigrationsA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Associados.Domain.AssociadoRoot.Associado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("Name");

                    b.Property<string>("Uf");

                    b.HasKey("Id");

                    b.ToTable("Associado");
                });

            modelBuilder.Entity("Associados.Domain.DependenteRoot.Dependente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AssociadoId");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("GrauParentesco");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("AssociadoId");

                    b.ToTable("Dependente");
                });

            modelBuilder.Entity("Associados.Domain.UsuarioRoot.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Associados.Domain.DependenteRoot.Dependente", b =>
                {
                    b.HasOne("Associados.Domain.AssociadoRoot.Associado")
                        .WithMany("Dependentes")
                        .HasForeignKey("AssociadoId");
                });
#pragma warning restore 612, 618
        }
    }
}
