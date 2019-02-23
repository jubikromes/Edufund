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

                    b.Property<int>("EduFundSystemId");

                    b.Property<decimal>("InitialInvestedCapital");

                    b.Property<int>("MemberCount");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("NoPerCycle");

                    b.Property<int>("ReferralCount");

                    b.Property<string>("Title");

                    b.Property<int>("UplineCount");

                    b.HasKey("Id");

                    b.HasIndex("EduFundSystemId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("Edufund.Data.Entities.EduFundSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<decimal>("EntryFee");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EduFundSystem");
                });

            modelBuilder.Entity("Edufund.Data.Entities.EduWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ModifiedDate");

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

                    b.Property<string>("EduUserId");

                    b.Property<int?>("MemberWalletId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("OrderBy");

                    b.Property<int?>("ParentMemberId");

                    b.Property<int?>("WalletId");

                    b.HasKey("Id");

                    b.HasIndex("EduUserId");

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

                    b.Property<DateTime?>("ModifiedDate");

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

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("ReferedId");

                    b.Property<int?>("RefererId");

                    b.HasKey("Id");

                    b.HasIndex("ReferedId");

                    b.HasIndex("RefererId");

                    b.ToTable("Referral");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int>("Kyc");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NextofKinName");

                    b.Property<string>("NextofKinNumber");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityAnswer1");

                    b.Property<string>("SecurityAnswer2");

                    b.Property<string>("SecurityAnswer3");

                    b.Property<string>("SecurityQuestion1");

                    b.Property<string>("SecurityQuestion2");

                    b.Property<string>("SecurityQuestion3");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("UserId1");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("UserId1");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Edufund.Data.Entities.Board", b =>
                {
                    b.HasOne("Edufund.Data.Entities.EduFundSystem", "EduFundSystem")
                        .WithMany("Boards")
                        .HasForeignKey("EduFundSystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edufund.Data.Entities.Member", b =>
                {
                    b.HasOne("Edufund.Data.Identity.EduUser", "EduUser")
                        .WithMany()
                        .HasForeignKey("EduUserId");

                    b.HasOne("Edufund.Data.Entities.MemberWallet", "MemberWallet")
                        .WithMany()
                        .HasForeignKey("MemberWalletId");
                });

            modelBuilder.Entity("Edufund.Data.Entities.Referral", b =>
                {
                    b.HasOne("Edufund.Data.Entities.Member", "Refered")
                        .WithMany("AllReferred")
                        .HasForeignKey("ReferedId");

                    b.HasOne("Edufund.Data.Entities.Member", "Referer")
                        .WithMany("Referrals")
                        .HasForeignKey("RefererId");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduRoleClaim", b =>
                {
                    b.HasOne("Edufund.Data.Identity.EduRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserClaim", b =>
                {
                    b.HasOne("Edufund.Data.Identity.EduUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edufund.Data.Identity.EduUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserLogin", b =>
                {
                    b.HasOne("Edufund.Data.Identity.EduUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edufund.Data.Identity.EduUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserRole", b =>
                {
                    b.HasOne("Edufund.Data.Identity.EduRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edufund.Data.Identity.EduUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edufund.Data.Identity.EduUserToken", b =>
                {
                    b.HasOne("Edufund.Data.Identity.EduUser")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edufund.Data.Identity.EduUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
