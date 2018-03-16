﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1_identity.Data;

namespace WebApplication1_identity.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180313065449_userteam")]
    partial class userteam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
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
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("DDUserId");

                    b.Property<int>("InfoStatus");

                    b.Property<string>("TagsId");

                    b.Property<string>("TeamsId");

                    b.Property<string>("Title")
                        .HasMaxLength(20);

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("DDUserId");

                    b.HasIndex("TopicId");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.InfoTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InfoId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("TagId");

                    b.ToTable("InfoTag");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.InfoTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InfoId");

                    b.Property<long?>("TeamCode");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("TeamCode");

                    b.ToTable("InfoTeam");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DDUserId");

                    b.Property<int>("Socre");

                    b.Property<string>("Title")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("DDUserId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Team", b =>
                {
                    b.Property<long>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<long>("ParentCode");

                    b.Property<int?>("TopicId");

                    b.HasKey("Code");

                    b.HasIndex("ParentCode");

                    b.HasIndex("TopicId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TeamTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TagId");

                    b.Property<long?>("TeamCode");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TeamCode");

                    b.ToTable("TeamTag");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TeamTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("TeamCode");

                    b.Property<int?>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("TeamCode");

                    b.HasIndex("TopicId");

                    b.ToTable("TeamTopic");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TestTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TestTable");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatTime");

                    b.Property<string>("DDUserId");

                    b.Property<string>("Des");

                    b.Property<string>("Title")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("DDUserId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TopicAudit", b =>
                {
                    b.Property<int>("TopicId");

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreatTime");

                    b.Property<string>("Reason")
                        .HasMaxLength(50);

                    b.HasKey("TopicId");

                    b.ToTable("TopicAudit");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.UserExtend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BelongTeamId");

                    b.Property<string>("MyTags");

                    b.Property<string>("MyTeams");

                    b.Property<string>("MyTopic");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("BelongTeamId");

                    b.ToTable("UserExtend");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.UserTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("TeamId");

                    b.Property<string>("UserExtendId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserExtendId");

                    b.ToTable("UserTeam");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.UserTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TopicId");

                    b.Property<string>("UserExtendId");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserExtendId");

                    b.ToTable("UserTopic");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1_identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Info", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.UserExtend", "DDUser")
                        .WithMany("Info")
                        .HasForeignKey("DDUserId");

                    b.HasOne("WebApplication1_identity.Data.Topic", "Topic")
                        .WithMany("Infos")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1_identity.Data.InfoTag", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1_identity.Data.Tag", "Tag")
                        .WithMany("Infos")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1_identity.Data.InfoTeam", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1_identity.Data.Team", "Team")
                        .WithMany("Infos")
                        .HasForeignKey("TeamCode");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Tag", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.UserExtend", "DDUser")
                        .WithMany()
                        .HasForeignKey("DDUserId");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Team", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Team", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1_identity.Data.Topic")
                        .WithMany("Team")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TeamTag", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Tag", "Tag")
                        .WithMany("TeamTag")
                        .HasForeignKey("TagId");

                    b.HasOne("WebApplication1_identity.Data.Team", "Team")
                        .WithMany("TeamTag")
                        .HasForeignKey("TeamCode");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TeamTopic", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Team", "Team")
                        .WithMany("Topic")
                        .HasForeignKey("TeamCode");

                    b.HasOne("WebApplication1_identity.Data.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.Topic", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.UserExtend", "DDUser")
                        .WithMany()
                        .HasForeignKey("DDUserId");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.TopicAudit", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Topic", "Topic")
                        .WithOne("TopicAudit")
                        .HasForeignKey("WebApplication1_identity.Data.TopicAudit", "TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1_identity.Data.UserExtend", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Team", "BelongTeam")
                        .WithMany()
                        .HasForeignKey("BelongTeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1_identity.Data.UserTeam", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1_identity.Data.UserExtend", "UserExtend")
                        .WithMany("Team")
                        .HasForeignKey("UserExtendId");
                });

            modelBuilder.Entity("WebApplication1_identity.Data.UserTopic", b =>
                {
                    b.HasOne("WebApplication1_identity.Data.Topic", "Topic")
                        .WithMany("UserExtend")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1_identity.Data.UserExtend", "UserExtend")
                        .WithMany("Topic")
                        .HasForeignKey("UserExtendId");
                });
#pragma warning restore 612, 618
        }
    }
}