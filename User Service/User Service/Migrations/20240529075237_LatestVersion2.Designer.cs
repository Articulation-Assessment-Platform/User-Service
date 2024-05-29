﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using User_Service.Data;

#nullable disable

namespace User_Service.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20240529075237_LatestVersion2")]
    partial class LatestVersion2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("User_Service.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archived")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("SpeechTherapistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SpeechTherapistId");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("User_Service.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("User_Service.Models.SpeechTherapist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SpeechTherapist");
                });

            modelBuilder.Entity("User_Service.Models.Child", b =>
                {
                    b.HasOne("User_Service.Models.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User_Service.Models.SpeechTherapist", "SpeechTherapist")
                        .WithMany("children")
                        .HasForeignKey("SpeechTherapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("SpeechTherapist");
                });

            modelBuilder.Entity("User_Service.Models.Parent", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("User_Service.Models.SpeechTherapist", b =>
                {
                    b.Navigation("children");
                });
#pragma warning restore 612, 618
        }
    }
}
