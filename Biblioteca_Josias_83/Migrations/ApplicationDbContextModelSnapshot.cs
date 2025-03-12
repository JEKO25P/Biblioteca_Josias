﻿// <auto-generated />
using Biblioteca_Josias_83.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca_Josias_83.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Autor", b =>
                {
                    b.Property<int>("PkAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkAutor"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Categoria", b =>
                {
                    b.Property<int>("PkCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkCategoria"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Favorito", b =>
                {
                    b.Property<int>("PKFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKFavorito"));

                    b.Property<int>("FkLibro")
                        .HasColumnType("int");

                    b.Property<int>("FkUsuario")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioPkUsuario")
                        .HasColumnType("int");

                    b.HasKey("PKFavorito");

                    b.HasIndex("FkLibro");

                    b.HasIndex("UsuarioPkUsuario");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.LibrosCategorias", b =>
                {
                    b.Property<int>("PkLibrosCategorias")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkLibrosCategorias"));

                    b.Property<int>("FkCategoria")
                        .HasColumnType("int");

                    b.Property<int>("FkLibro")
                        .HasColumnType("int");

                    b.HasKey("PkLibrosCategorias");

                    b.HasIndex("FkCategoria");

                    b.HasIndex("FkLibro");

                    b.ToTable("LibrosCategorias");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"));

                    b.Property<int>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Libro", b =>
                {
                    b.Property<int>("PkLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkLibro"));

                    b.Property<int>("AñoPublicacion")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editorial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FkAutor")
                        .HasColumnType("int");

                    b.Property<int>("FkCategoria")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagen")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlLectura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkLibro");

                    b.HasIndex("FkAutor");

                    b.HasIndex("FkCategoria");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Favorito", b =>
                {
                    b.HasOne("Biblioteca_Josias_83.Models.Libro", "Libros")
                        .WithMany()
                        .HasForeignKey("FkLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_Josias_83.Models.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioPkUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libros");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.LibrosCategorias", b =>
                {
                    b.HasOne("Biblioteca_Josias_83.Models.Domain.Categoria", "Categorias")
                        .WithMany("LibrosCategorias")
                        .HasForeignKey("FkCategoria")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Biblioteca_Josias_83.Models.Libro", "Libros")
                        .WithMany("LibrosCategorias")
                        .HasForeignKey("FkLibro")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categorias");

                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Usuario", b =>
                {
                    b.HasOne("Biblioteca_Josias_83.Models.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Libro", b =>
                {
                    b.HasOne("Biblioteca_Josias_83.Models.Domain.Autor", "Autores")
                        .WithMany()
                        .HasForeignKey("FkAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_Josias_83.Models.Domain.Categoria", "Categorias")
                        .WithMany()
                        .HasForeignKey("FkCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autores");

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Domain.Categoria", b =>
                {
                    b.Navigation("LibrosCategorias");
                });

            modelBuilder.Entity("Biblioteca_Josias_83.Models.Libro", b =>
                {
                    b.Navigation("LibrosCategorias");
                });
#pragma warning restore 612, 618
        }
    }
}
