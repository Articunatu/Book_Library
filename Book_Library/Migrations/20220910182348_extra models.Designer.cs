﻿// <auto-generated />
using System;
using Book_Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Book_Library.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20220910182348_extra models")]
    partial class extramodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Book_Library.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Book_Library.Models.Authorship", b =>
                {
                    b.Property<int>("AuthorshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("Authorship_AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("Authorship_BookID")
                        .HasColumnType("int");

                    b.HasKey("AuthorshipID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Authorships");
                });

            modelBuilder.Entity("Book_Library.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BurrowerID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("BookID");

                    b.HasIndex("BurrowerID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Book_Library.Models.BookCopy", b =>
                {
                    b.Property<int>("CopyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("BookStatus")
                        .HasColumnType("int");

                    b.Property<int>("ShelfID")
                        .HasColumnType("int");

                    b.HasKey("CopyID");

                    b.HasIndex("BookID");

                    b.HasIndex("ShelfID");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("Book_Library.Models.Burrower", b =>
                {
                    b.Property<int>("BurrowerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SecurityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BurrowerID");

                    b.ToTable("Burrowers");
                });

            modelBuilder.Entity("Book_Library.Models.Library", b =>
                {
                    b.Property<int>("LibraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LibraryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibraryID");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("Book_Library.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfLoanRenewals")
                        .HasColumnType("int");

                    b.Property<int?>("BurrowerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfLoan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Loan_BookCopyID")
                        .HasColumnType("int");

                    b.Property<int>("Loan_BurrowerID")
                        .HasColumnType("int");

                    b.HasKey("LoanID");

                    b.HasIndex("BurrowerID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Book_Library.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("BurrowerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReserved")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibraryID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("BookID");

                    b.HasIndex("BurrowerID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Book_Library.Models.Shelf", b =>
                {
                    b.Property<int>("ShelfID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LibraryID")
                        .HasColumnType("int");

                    b.Property<string>("ShelfName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShelfID");

                    b.HasIndex("LibraryID");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("Book_Library.Models.Authorship", b =>
                {
                    b.HasOne("Book_Library.Models.Author", null)
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("AuthorID");
                });

            modelBuilder.Entity("Book_Library.Models.Book", b =>
                {
                    b.HasOne("Book_Library.Models.Burrower", null)
                        .WithMany("Checklist")
                        .HasForeignKey("BurrowerID");
                });

            modelBuilder.Entity("Book_Library.Models.BookCopy", b =>
                {
                    b.HasOne("Book_Library.Models.Book", null)
                        .WithMany("Copies")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Library.Models.Shelf", null)
                        .WithMany("BooksOfShelf")
                        .HasForeignKey("ShelfID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Book_Library.Models.Loan", b =>
                {
                    b.HasOne("Book_Library.Models.Burrower", null)
                        .WithMany("BurrowedBooks")
                        .HasForeignKey("BurrowerID");
                });

            modelBuilder.Entity("Book_Library.Models.Reservation", b =>
                {
                    b.HasOne("Book_Library.Models.Book", null)
                        .WithMany("Reservation")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Library.Models.Burrower", null)
                        .WithMany("Reservations")
                        .HasForeignKey("BurrowerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Book_Library.Models.Shelf", b =>
                {
                    b.HasOne("Book_Library.Models.Library", null)
                        .WithMany("Shelves")
                        .HasForeignKey("LibraryID");
                });
#pragma warning restore 612, 618
        }
    }
}
