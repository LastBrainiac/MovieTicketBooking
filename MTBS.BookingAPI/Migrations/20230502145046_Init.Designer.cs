﻿// <auto-generated />
using System;
using MTBS.BookingAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MTBS.BookingAPI.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20230502145046_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MTBS.BookingAPI.Models.BookingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingHeaderId")
                        .HasColumnType("int");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ScreeningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.Property<int>("TicketQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingHeaderId");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("MTBS.BookingAPI.Models.BookingHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookingHeaders");
                });

            modelBuilder.Entity("MTBS.BookingAPI.Models.ReservedSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingDetailsId");

                    b.ToTable("ReservedSeats");
                });

            modelBuilder.Entity("MTBS.BookingAPI.Models.BookingDetails", b =>
                {
                    b.HasOne("MTBS.BookingAPI.Models.BookingHeader", "BookingHeader")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingHeader");
                });

            modelBuilder.Entity("MTBS.BookingAPI.Models.ReservedSeat", b =>
                {
                    b.HasOne("MTBS.BookingAPI.Models.BookingDetails", "BookingDetails")
                        .WithMany("ReservedSeats")
                        .HasForeignKey("BookingDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDetails");
                });

            modelBuilder.Entity("MTBS.BookingAPI.Models.BookingDetails", b =>
                {
                    b.Navigation("ReservedSeats");
                });

            modelBuilder.Entity("MTBS.BookingAPI.Models.BookingHeader", b =>
                {
                    b.Navigation("BookingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
