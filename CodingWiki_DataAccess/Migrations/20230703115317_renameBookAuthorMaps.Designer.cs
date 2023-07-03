﻿// <auto-generated />
using System;
using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230703115317_renameBookAuthorMaps")]
    partial class renameBookAuthorMaps
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingWiki_Model.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Book_Id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Book_Id");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Book_Id = 1,
                            ISBN = "133B12",
                            Price = 10.5m,
                            Publisher_Id = 1,
                            Title = "Bible"
                        },
                        new
                        {
                            Book_Id = 2,
                            ISBN = "133B15",
                            Price = 9.5m,
                            Publisher_Id = 1,
                            Title = "ABC"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookAuthorMaps", b =>
                {
                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Author_Id1")
                        .HasColumnType("int");

                    b.Property<int?>("Book_Id1")
                        .HasColumnType("int");

                    b.HasKey("Book_Id", "Author_Id");

                    b.HasIndex("Author_Id1");

                    b.HasIndex("Book_Id1");

                    b.ToTable("BookAuthorMaps");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Author_fluent");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Book", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Book_Id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Book_Id");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Book_fluent");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookAuthorMap", b =>
                {
                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.HasKey("Book_Id", "Author_Id");

                    b.HasIndex("Author_Id");

                    b.ToTable("BookAuthorMap_fluent");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int")
                        .HasColumnName("NoOfChapters");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("Fluent_BookDetails", (string)null);
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publisher_fluent");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Publisher_Id = 1,
                            Location = "Auckland",
                            Name = "Wayne"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategory_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SubCategory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookAuthorMaps", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Author", "Author")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Author_Id1");

                    b.HasOne("CodingWiki_Model.Models.Book", "Book")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Book_Id1");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookDetail", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("CodingWiki_Model.Models.BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Book", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Fluent_Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookAuthorMap", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Fluent_Author", "Author")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingWiki_Model.Models.Fluent_Book", "Book")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookDetail", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Fluent_Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("CodingWiki_Model.Models.Fluent_BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Author", b =>
                {
                    b.Navigation("BookAuthorMap");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Navigation("BookAuthorMap");

                    b.Navigation("BookDetail");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Author", b =>
                {
                    b.Navigation("BookAuthorMap");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Book", b =>
                {
                    b.Navigation("BookAuthorMap");

                    b.Navigation("BookDetail");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
