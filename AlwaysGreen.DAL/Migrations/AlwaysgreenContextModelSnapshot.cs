﻿// <auto-generated />
using System;
using AlwaysGreen.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlwaysGreen.DAL.Migrations
{
    [DbContext(typeof(AlwaysgreenContext))]
    partial class AlwaysgreenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("char(4)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Courier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.Property<string>("VATnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("TransportId");

                    b.ToTable("Couriers");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Delivery", b =>
                {
                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.Property<int>("EmptybottleId")
                        .HasColumnType("int");

                    b.Property<float?>("Prix")
                        .HasColumnType("real");

                    b.Property<int>("QuantityTransported")
                        .HasColumnType("int");

                    b.HasKey("TransportId", "EmptybottleId");

                    b.HasIndex("EmptybottleId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Emptybottle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Prix")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emptybottles");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AgencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("TransportId");

                    b.ToTable("Location");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Location");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("ParticularId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ParticularId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Particular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(75)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Particulars");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Siret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NIC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siren")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sirets");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Company", b =>
                {
                    b.HasBaseType("AlwaysGreen.Domain.Entities.Location");

                    b.Property<int?>("SiretId")
                        .HasColumnType("int");

                    b.Property<string>("VATnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SiretId");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Depot", b =>
                {
                    b.HasBaseType("AlwaysGreen.Domain.Entities.Location");

                    b.HasDiscriminator().HasValue("Depot");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Store", b =>
                {
                    b.HasBaseType("AlwaysGreen.Domain.Entities.Location");

                    b.Property<bool>("IsPickUpPoint")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStorePoint")
                        .HasColumnType("bit");

                    b.Property<int>("SiretId")
                        .HasColumnType("int");

                    b.Property<string>("VATnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SiretId");

                    b.ToTable("Location", t =>
                        {
                            t.Property("SiretId")
                                .HasColumnName("Store_SiretId");

                            t.Property("VATnumber")
                                .HasColumnName("Store_VATnumber");
                        });

                    b.HasDiscriminator().HasValue("Store");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Courier", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlwaysGreen.Domain.Entities.Transport", "Transport")
                        .WithMany("Courriers")
                        .HasForeignKey("TransportId");

                    b.Navigation("Address");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Delivery", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Emptybottle", "Emptybottle")
                        .WithMany("Deliveries")
                        .HasForeignKey("EmptybottleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlwaysGreen.Domain.Entities.Transport", "Transport")
                        .WithMany("Deliveries")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emptybottle");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Location", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlwaysGreen.Domain.Entities.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId");

                    b.Navigation("Address");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Login", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Location", "Depot")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("AlwaysGreen.Domain.Entities.Particular", "Particular")
                        .WithMany()
                        .HasForeignKey("ParticularId");

                    b.Navigation("Depot");

                    b.Navigation("Particular");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Particular", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Company", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Siret", "Siret")
                        .WithMany()
                        .HasForeignKey("SiretId");

                    b.Navigation("Siret");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Store", b =>
                {
                    b.HasOne("AlwaysGreen.Domain.Entities.Siret", "Siret")
                        .WithMany()
                        .HasForeignKey("SiretId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siret");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Emptybottle", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("AlwaysGreen.Domain.Entities.Transport", b =>
                {
                    b.Navigation("Courriers");

                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
