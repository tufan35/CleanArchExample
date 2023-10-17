﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017151405_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Addresses")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TaxPayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaxPayerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Advisor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AddressesId")
                        .HasColumnType("integer");

                    b.Property<int>("ContactId")
                        .HasColumnType("integer");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressesId");

                    b.HasIndex("ContactId");

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("Domain.Entities.BusinessApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TaxPayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaxPayerId");

                    b.ToTable("BusinessApplications");
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TaxPayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaxPayerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Domain.Entities.Obligation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ObligationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TaxPayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaxPayerId");

                    b.ToTable("Obligations");
                });

            modelBuilder.Entity("Domain.Entities.TaxPayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AdvisorId")
                        .HasColumnType("uuid");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NaceCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdvisorId");

                    b.ToTable("TaxPayers");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("Domain.Entities.TaxPayer", null)
                        .WithMany("Addresses")
                        .HasForeignKey("TaxPayerId");
                });

            modelBuilder.Entity("Domain.Entities.Advisor", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Addresses")
                        .WithMany()
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addresses");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Domain.Entities.BusinessApplication", b =>
                {
                    b.HasOne("Domain.Entities.TaxPayer", null)
                        .WithMany("BusinessApplications")
                        .HasForeignKey("TaxPayerId");
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.HasOne("Domain.Entities.TaxPayer", null)
                        .WithMany("Contacts")
                        .HasForeignKey("TaxPayerId");
                });

            modelBuilder.Entity("Domain.Entities.Obligation", b =>
                {
                    b.HasOne("Domain.Entities.TaxPayer", null)
                        .WithMany("Obligations")
                        .HasForeignKey("TaxPayerId");
                });

            modelBuilder.Entity("Domain.Entities.TaxPayer", b =>
                {
                    b.HasOne("Domain.Entities.Advisor", null)
                        .WithMany("TaxPayers")
                        .HasForeignKey("AdvisorId");
                });

            modelBuilder.Entity("Domain.Entities.Advisor", b =>
                {
                    b.Navigation("TaxPayers");
                });

            modelBuilder.Entity("Domain.Entities.TaxPayer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("BusinessApplications");

                    b.Navigation("Contacts");

                    b.Navigation("Obligations");
                });
#pragma warning restore 612, 618
        }
    }
}
