﻿// <auto-generated />
using System;
using DocVault.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DocVault.Repository.Migrations
{
    [DbContext(typeof(LPSDatabaseContext))]
    partial class LPSDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DocVault.Domain.UploadedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("FileContent")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UploadedFiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                            Created = new DateTime(2024, 4, 4, 13, 18, 34, 798, DateTimeKind.Utc).AddTicks(2760),
                            CreatedBy = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                            FileContent = new byte[] { 37, 80, 68, 70, 45, 49, 46, 53, 13, 10, 37, 181, 181, 181, 181, 13, 10, 49, 32, 48, 32, 111, 98, 106, 13, 10, 60, 60, 47, 84, 121, 112, 101, 47, 67, 97, 116, 97, 108, 111, 103, 47, 80, 97, 103, 101, 115, 32, 50, 32, 48, 32, 82, 47, 79, 112, 101, 110, 32, 65, 99, 116, 105, 111, 110, 60, 60, 47, 80, 97, 114, 101, 110, 116, 32, 50, 32, 48, 32, 82, 47, 83, 47, 84, 121, 112, 101, 47, 80, 97, 103, 101, 47, 67, 111, 110, 116, 101, 110, 116, 115, 32, 50, 32, 48, 32, 82, 47, 77, 101, 100, 105, 97, 66, 111, 120, 91, 48, 32, 48, 32, 54, 48, 54, 32, 53, 56, 52, 93, 47, 66, 91, 48, 32, 48, 32, 49, 50, 55, 46, 50, 53, 50, 53, 53, 93, 47, 70, 49, 91, 48, 93, 47, 70, 50, 91, 48, 93, 47, 67, 83, 91, 47, 71, 97, 109, 97, 93, 47, 70, 52, 91, 47, 77, 111, 100, 68, 101, 99, 111, 100, 101, 93, 47, 70, 53, 91, 48, 32, 49, 50, 51, 53, 93, 47, 73, 83, 84, 47, 84, 121, 112, 101, 47, 84, 101, 120, 116, 93, 62, 62, 62, 115, 116, 114, 101, 97, 109, 10, 120, 156, 237, 193, 11, 13, 0, 32, 8, 3, 48, 245, 99, 72, 108, 74, 162, 36, 132, 31, 154, 0, 213, 14, 76, 12, 158, 241, 227, 201, 131, 241, 134, 13, 1, 196, 23, 131, 243, 60, 1, 167, 147, 241, 35, 125, 52, 184, 99, 6, 36, 62, 17, 9, 73, 159, 20, 65, 242, 66, 0, 18, 182, 100, 199, 30, 40, 3, 24, 184, 104, 107, 102, 177, 52, 154, 173, 118, 6, 95, 153, 116, 179, 124, 121, 61, 183, 255, 222, 155, 247, 237, 219, 183, 239, 197, 229, 114, 57, 157, 206, 231, 243, 249, 252, 126, 191, 223, 239, 247, 251, 253, 254, 255, 255, 255, 255, 127, 177, 215, 255, 227, 1, 23, 162, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 },
                            FileName = "HeloWord.pdf"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
