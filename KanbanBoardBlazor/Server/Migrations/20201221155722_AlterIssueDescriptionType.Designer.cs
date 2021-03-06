﻿// <auto-generated />
using System;
using KanbanBoardBlazor.Server.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace KanbanBoardBlazor.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201221155722_AlterIssueDescriptionType")]
    partial class AlterIssueDescriptionType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ISSUE_TRACKER")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Assignment", b =>
                {
                    b.Property<long>("IssueId")
                        .HasColumnName("ISSUE_ID")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("UserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IssueId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ASSIGNMENT");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnType("NUMBER(19)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("CustomerId");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Issue", b =>
                {
                    b.Property<long>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ISSUE_ID")
                        .HasColumnType("NUMBER(19)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CREATED_AT")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnName("DEADLINE")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("NCLOB");

                    b.Property<bool>("IsOpen")
                        .HasColumnName("IS_OPEN")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("Priority")
                        .HasColumnName("PRIORITY")
                        .HasColumnType("NUMBER(10)");

                    b.Property<long?>("ProjectId")
                        .HasColumnName("PROJECT_ID")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long?>("StageId")
                        .HasColumnName("STAGE_ID")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Title")
                        .HasColumnName("TITLE")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UPDATED_AT")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("IssueId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StageId");

                    b.ToTable("ISSUE");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.IssueCustomer", b =>
                {
                    b.Property<long>("IssueId")
                        .HasColumnName("ISSUE_ID")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("CustomerId")
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IssueId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ISSUE_CUSTOMER");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.IssueTag", b =>
                {
                    b.Property<long>("IssueId")
                        .HasColumnName("ISSUE_ID")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("TagId")
                        .HasColumnName("TAG_ID")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IssueId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ISSUE_TAG");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PROJECT_ID")
                        .HasColumnType("NUMBER(19)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ProjectId");

                    b.ToTable("PROJECT");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Stage", b =>
                {
                    b.Property<long>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("STAGE_ID")
                        .HasColumnType("NUMBER(19)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnName("COLOR")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("Limit")
                        .HasColumnName("LIMIT")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Position")
                        .HasColumnName("POSITION")
                        .HasColumnType("NUMBER(10)");

                    b.Property<long>("ProjectId")
                        .HasColumnName("PROJECT_ID")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Title")
                        .HasColumnName("TITLE")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("StageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("STAGE");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Tag", b =>
                {
                    b.Property<long>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TAG_ID")
                        .HasColumnType("NUMBER(19)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CssClass")
                        .HasColumnName("CSS_CLASS")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Text")
                        .HasColumnName("TEXT")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("TagId");

                    b.ToTable("TAG");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID")
                        .HasColumnType("NUMBER(19)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnName("FIRST_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LastName")
                        .HasColumnName("LAST_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Password")
                        .HasColumnName("PASSWORD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Username")
                        .HasColumnName("USERNAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserId");

                    b.ToTable("APP_USER");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Assignment", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Issue", "Issue")
                        .WithMany("Assignees")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.User", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Issue", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId");

                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Stage", "Stage")
                        .WithMany("Issues")
                        .HasForeignKey("StageId");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.IssueCustomer", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Customer", "Customer")
                        .WithMany("IssueCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Issue", "Issue")
                        .WithMany("IssueCustomers")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.IssueTag", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Issue", "Issue")
                        .WithMany("IssueTags")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Tag", "Tag")
                        .WithMany("IssueTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Stage", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
