﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ledger.Models;

namespace ledger.Migrations
{
    [DbContext(typeof(LedgerContext))]
    partial class LedgerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("ledger.Models.Account", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<string>("SortCode");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ledger.Models.Reference", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("References");
                });

            modelBuilder.Entity("ledger.Models.Transaction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountID");

                    b.Property<int>("Amount");

                    b.Property<bool>("Debit");

                    b.Property<string>("Description");

                    b.Property<Guid?>("ReferenceID");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("ReferenceID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ledger.Models.Transaction", b =>
                {
                    b.HasOne("ledger.Models.Reference", "Reference")
                        .WithMany()
                        .HasForeignKey("ReferenceID");
                });
#pragma warning restore 612, 618
        }
    }
}
