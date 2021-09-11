﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Models.Migrations
{
    [DbContext(typeof(ManagerDbContext))]
    partial class ManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.System.MenuAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ActionStatus")
                        .HasColumnType("int");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<string>("ActionUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MenuAction");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActionName = "系统管理",
                            ActionStatus = 1,
                            ActionType = 1,
                            ActionUrl = "/",
                            Code = "System",
                            CreateTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(5679),
                            EditTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(5926),
                            Icon = "layui-icon-set",
                            IsDelete = 0,
                            ParentId = 0,
                            Sort = 1
                        },
                        new
                        {
                            Id = 2,
                            ActionName = "用户管理",
                            ActionStatus = 1,
                            ActionType = 1,
                            ActionUrl = "/System/User",
                            Code = "System.User",
                            CreateTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(7026),
                            EditTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(7033),
                            Icon = "",
                            IsDelete = 0,
                            ParentId = 1,
                            Sort = 1
                        },
                        new
                        {
                            Id = 3,
                            ActionName = "角色管理",
                            ActionStatus = 1,
                            ActionType = 1,
                            ActionUrl = "/System/Role",
                            Code = "System.Role",
                            CreateTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(7072),
                            EditTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(7072),
                            Icon = "",
                            IsDelete = 0,
                            ParentId = 1,
                            Sort = 2
                        },
                        new
                        {
                            Id = 4,
                            ActionName = "菜单管理",
                            ActionStatus = 1,
                            ActionType = 1,
                            ActionUrl = "/System/Menu",
                            Code = "System.Role",
                            CreateTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(7075),
                            EditTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(7075),
                            Icon = "",
                            IsDelete = 0,
                            ParentId = 1,
                            Sort = 3
                        });
                });

            modelBuilder.Entity("Models.System.RoleAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleAction");
                });

            modelBuilder.Entity("Models.System.RoleInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("RoleInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(3698),
                            EditTime = new DateTime(2021, 9, 11, 17, 56, 53, 568, DateTimeKind.Local).AddTicks(3701),
                            IsDelete = 0,
                            RoleName = "Administrator",
                            RoleStatus = 0
                        });
                });

            modelBuilder.Entity("Models.System.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Account")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Account = "admin",
                            AccountStatus = 1,
                            CreateTime = new DateTime(2021, 9, 11, 17, 56, 53, 566, DateTimeKind.Local).AddTicks(3754),
                            EditTime = new DateTime(2021, 9, 11, 17, 56, 53, 567, DateTimeKind.Local).AddTicks(2524),
                            IsDelete = 0,
                            Mobile = "",
                            Nickname = "Administrator",
                            Password = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
                            RoleId = 1,
                            UserType = 1
                        });
                });

            modelBuilder.Entity("Models.System.RoleAction", b =>
                {
                    b.HasOne("Models.System.MenuAction", "MenuAction")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.System.RoleInfo", "RoleInfo")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuAction");

                    b.Navigation("RoleInfo");
                });

            modelBuilder.Entity("Models.System.UserInfo", b =>
                {
                    b.HasOne("Models.System.RoleInfo", "RoleInfo")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
