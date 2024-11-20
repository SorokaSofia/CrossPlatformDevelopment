﻿// <auto-generated />
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace lab6.Migrations
{
    [DbContext(typeof(CarServiceCenterContext))]
    partial class CarServiceCenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Lab6.Data.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LicenceNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherCarDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Lab6.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherCustomerDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab6.Data.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherManufacturerDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Lab6.Data.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MechanicName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherMechanicDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("Lab6.Data.MechanicsOnServices", b =>
                {
                    b.Property<int>("MechanicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SvcBookingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MechanicId", "SvcBookingId");

                    b.HasIndex("SvcBookingId");

                    b.ToTable("MechanicsOnServices");
                });

            modelBuilder.Entity("Lab6.Data.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherModelDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Lab6.Data.ServiceBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LicenceNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherSvcBookingDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ServiceBookings");
                });

            modelBuilder.Entity("Lab6.Data.Car", b =>
                {
                    b.HasOne("Lab6.Data.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Lab6.Data.MechanicsOnServices", b =>
                {
                    b.HasOne("Lab6.Data.Mechanic", "Mechanic")
                        .WithMany("MechanicsOnServices")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.ServiceBooking", "ServiceBooking")
                        .WithMany("MechanicsOnServices")
                        .HasForeignKey("SvcBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanic");

                    b.Navigation("ServiceBooking");
                });

            modelBuilder.Entity("Lab6.Data.Model", b =>
                {
                    b.HasOne("Lab6.Data.Manufacturer", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Lab6.Data.ServiceBooking", b =>
                {
                    b.HasOne("Lab6.Data.Car", "Car")
                        .WithMany("ServiceBookings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Customer", "Customer")
                        .WithMany("ServiceBookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab6.Data.Car", b =>
                {
                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("Lab6.Data.Customer", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("Lab6.Data.Manufacturer", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Lab6.Data.Mechanic", b =>
                {
                    b.Navigation("MechanicsOnServices");
                });

            modelBuilder.Entity("Lab6.Data.Model", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Lab6.Data.ServiceBooking", b =>
                {
                    b.Navigation("MechanicsOnServices");
                });
#pragma warning restore 612, 618
        }
    }
}