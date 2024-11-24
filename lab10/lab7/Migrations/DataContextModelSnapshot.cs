﻿// <auto-generated />
using System;
using Lab7.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace lab7.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab7.Models.Car", b =>
                {
                    b.Property<string>("LicenceNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentMileage")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("EngineSize")
                        .HasColumnType("float");

                    b.Property<string>("ModelCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OtherCarDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicenceNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ModelCode");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Lab7.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab7.Models.Manufacturer", b =>
                {
                    b.Property<string>("ManufacturerCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherManufacturerDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerCode");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Lab7.Models.Mechanic", b =>
                {
                    b.Property<int>("MechanicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MechanicId"));

                    b.Property<string>("MechanicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherMechanicDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MechanicId");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("Lab7.Models.MechanicsOnService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.Property<int>("SvcBookingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MechanicId");

                    b.HasIndex("SvcBookingId");

                    b.ToTable("MechanicsOnServices");
                });

            modelBuilder.Entity("Lab7.Models.Model", b =>
                {
                    b.Property<string>("ModelCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManufacturerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherModelDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelCode");

                    b.HasIndex("ManufacturerCode");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Lab7.Models.ServiceBooking", b =>
                {
                    b.Property<int>("SvcBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SvcBookingId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatetimeOfService")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OtherSvcBookingDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentReceivedYn")
                        .HasColumnType("bit");

                    b.HasKey("SvcBookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LicenceNumber");

                    b.ToTable("ServiceBookings");
                });

            modelBuilder.Entity("Lab7.Models.Car", b =>
                {
                    b.HasOne("Lab7.Models.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab7.Models.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Lab7.Models.MechanicsOnService", b =>
                {
                    b.HasOne("Lab7.Models.Mechanic", "Mechanic")
                        .WithMany("MechanicsOnServices")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab7.Models.ServiceBooking", "ServiceBooking")
                        .WithMany()
                        .HasForeignKey("SvcBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanic");

                    b.Navigation("ServiceBooking");
                });

            modelBuilder.Entity("Lab7.Models.Model", b =>
                {
                    b.HasOne("Lab7.Models.Manufacturer", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Lab7.Models.ServiceBooking", b =>
                {
                    b.HasOne("Lab7.Models.Customer", "Customer")
                        .WithMany("ServiceBookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab7.Models.Car", "Car")
                        .WithMany("ServiceBookings")
                        .HasForeignKey("LicenceNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab7.Models.Car", b =>
                {
                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("Lab7.Models.Customer", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("Lab7.Models.Manufacturer", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Lab7.Models.Mechanic", b =>
                {
                    b.Navigation("MechanicsOnServices");
                });

            modelBuilder.Entity("Lab7.Models.Model", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
