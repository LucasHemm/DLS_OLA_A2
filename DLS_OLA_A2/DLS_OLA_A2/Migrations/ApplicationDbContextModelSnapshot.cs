﻿// <auto-generated />
using System;
using DLS_OLA_A2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DLS_OLA_A2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DLS_OLA_A2.Objects.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.ChemicalBarrel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chemical")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("ChemicalBarrels");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Depot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Depots");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepotId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepotId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepotId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepotId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("GateStaffId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("GateStaffId");

                    b.HasIndex("JobId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("DepotId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepotId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Audit", b =>
                {
                    b.HasOne("DLS_OLA_A2.Objects.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.ChemicalBarrel", b =>
                {
                    b.HasOne("DLS_OLA_A2.Objects.Job", "Job")
                        .WithMany("Shipment")
                        .HasForeignKey("JobId");

                    b.HasOne("DLS_OLA_A2.Objects.Warehouse", "Warehouse")
                        .WithMany("Stock")
                        .HasForeignKey("WarehouseId");

                    b.Navigation("Job");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Job", b =>
                {
                    b.HasOne("DLS_OLA_A2.Objects.Depot", "Depot")
                        .WithMany()
                        .HasForeignKey("DepotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Depot");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Staff", b =>
                {
                    b.HasOne("DLS_OLA_A2.Objects.Depot", null)
                        .WithMany("Staff")
                        .HasForeignKey("DepotId");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Ticket", b =>
                {
                    b.HasOne("DLS_OLA_A2.Objects.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLS_OLA_A2.Objects.Staff", "GateStaff")
                        .WithMany()
                        .HasForeignKey("GateStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLS_OLA_A2.Objects.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("GateStaff");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Warehouse", b =>
                {
                    b.HasOne("DLS_OLA_A2.Objects.Depot", null)
                        .WithMany("Warehouses")
                        .HasForeignKey("DepotId");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Depot", b =>
                {
                    b.Navigation("Staff");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Job", b =>
                {
                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("DLS_OLA_A2.Objects.Warehouse", b =>
                {
                    b.Navigation("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
