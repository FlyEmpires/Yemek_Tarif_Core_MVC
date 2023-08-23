﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YemekTarifApi.Controllers.DataAccessLayer;

#nullable disable

namespace YemekTarifApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230821142654_mig_add_Table_NewsLetters")]
    partial class mig_add_Table_NewsLetters
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YemekTarifApi.Controllers.EntityLayer.Concrete.NewsLetters", b =>
                {
                    b.Property<int>("MailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MailID"), 1L, 1);

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MailStatus")
                        .HasColumnType("bit");

                    b.HasKey("MailID");

                    b.ToTable("NewsLetters");
                });
#pragma warning restore 612, 618
        }
    }
}