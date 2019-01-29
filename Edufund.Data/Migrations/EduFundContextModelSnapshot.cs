﻿// <auto-generated />
using System;
using Edufund.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Edufund.Data.Migrations
{
    [DbContext(typeof(EduFundContext))]
    partial class EduFundContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Edufund.Data.Entities.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutoRenew");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Cycles");

                    b.Property<string>("Description");

                    b.Property<decimal>("InitialInvestedCapital");

                    b.Property<int>("MemberCount");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("NoPerCycle");

                    b.Property<int>("ReferralCount");

                    b.Property<string>("Title");

                    b.Property<int>("UplineCount");

                    b.HasKey("Id");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("Edufund.Data.Entities.EduFundSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<decimal>("EntryFee");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("EduFundSystem");
                });

            modelBuilder.Entity("Edufund.Data.Entities.EduWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EduWallet");
                });

            modelBuilder.Entity("Edufund.Data.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Cycle");

                    b.Property<int?>("MemberWalletId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int?>("OrderBy");

                    b.Property<int?>("ParentMemberId");

                    b.Property<int?>("WalletId");

                    b.HasKey("Id");

                    b.HasIndex("MemberWalletId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Edufund.Data.Entities.MemberWallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MemberWallet");
                });

            modelBuilder.Entity("Edufund.Data.Entities.Referral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("ReferedId");

                    b.Property<int>("RefererId");

                    b.HasKey("Id");

                    b.HasIndex("ReferedId");

                    b.HasIndex("RefererId");

                    b.ToTable("Referral");
                });

            modelBuilder.Entity("Edufund.Data.Entities.EduFundSystem", b =>
                {
                    b.HasOne("Edufund.Data.Entities.Board", "Board")
                        .WithMany("EduFundSystem")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edufund.Data.Entities.Member", b =>
                {
                    b.HasOne("Edufund.Data.Entities.MemberWallet", "MemberWallet")
                        .WithMany()
                        .HasForeignKey("MemberWalletId");
                });

            modelBuilder.Entity("Edufund.Data.Entities.Referral", b =>
                {
                    b.HasOne("Edufund.Data.Entities.Member", "Refered")
                        .WithMany()
                        .HasForeignKey("ReferedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edufund.Data.Entities.Member", "Referer")
                        .WithMany()
                        .HasForeignKey("RefererId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
