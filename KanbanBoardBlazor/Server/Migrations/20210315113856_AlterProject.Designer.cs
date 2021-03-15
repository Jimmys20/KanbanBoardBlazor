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
    [Migration("20210315113856_AlterProject")]
    partial class AlterProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ISSUE_TRACKER")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Application", b =>
                {
                    b.Property<long>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("APPLICATION_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NAME");

                    b.HasKey("ApplicationId");

                    b.ToTable("APPLICATION");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Assignment", b =>
                {
                    b.Property<long>("IssueId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ISSUE_ID");

                    b.Property<long>("UserId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("USER_ID");

                    b.HasKey("IssueId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ASSIGNMENT");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("CUSTOMER_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NAME");

                    b.HasKey("CustomerId");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Issue", b =>
                {
                    b.Property<long>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ISSUE_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ApplicationId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("APPLICATION_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("CREATED_AT");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DEADLINE");

                    b.Property<string>("Description")
                        .HasColumnType("NCLOB")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_OPEN");

                    b.Property<int>("Priority")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PRIORITY");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PROJECT_ID");

                    b.Property<long?>("StageId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("STAGE_ID");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TITLE");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("UPDATED_AT");

                    b.HasKey("IssueId");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StageId");

                    b.ToTable("ISSUE");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.IssueCustomer", b =>
                {
                    b.Property<long>("IssueId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ISSUE_ID");

                    b.Property<long>("CustomerId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("CUSTOMER_ID");

                    b.HasKey("IssueId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ISSUE_CUSTOMER");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.IssueTag", b =>
                {
                    b.Property<long>("IssueId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ISSUE_ID");

                    b.Property<long>("TagId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("TAG_ID");

                    b.HasKey("IssueId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ISSUE_TAG");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PROJECT_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_OPEN");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NAME");

                    b.HasKey("ProjectId");

                    b.ToTable("PROJECT");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Stage", b =>
                {
                    b.Property<long>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("STAGE_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("COLOR");

                    b.Property<int?>("Limit")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("LIMIT");

                    b.Property<int>("Position")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("POSITION");

                    b.Property<long>("ProjectId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PROJECT_ID");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TITLE");

                    b.HasKey("StageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("STAGE");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Tag", b =>
                {
                    b.Property<long>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("TAG_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CssClass")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CSS_CLASS");

                    b.Property<string>("Text")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("TAG");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("USER_ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("Password")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Username")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("USERNAME");

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

                    b.Navigation("Issue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Issue", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Application", "Application")
                        .WithMany("Issues")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId");

                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Stage", "Stage")
                        .WithMany("Issues")
                        .HasForeignKey("StageId");

                    b.Navigation("Application");

                    b.Navigation("Project");

                    b.Navigation("Stage");
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

                    b.Navigation("Customer");

                    b.Navigation("Issue");
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

                    b.Navigation("Issue");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Stage", b =>
                {
                    b.HasOne("KanbanBoardBlazor.Server.Dal.Entities.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Application", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Customer", b =>
                {
                    b.Navigation("IssueCustomers");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Issue", b =>
                {
                    b.Navigation("Assignees");

                    b.Navigation("IssueCustomers");

                    b.Navigation("IssueTags");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Project", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Stages");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Stage", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.Tag", b =>
                {
                    b.Navigation("IssueTags");
                });

            modelBuilder.Entity("KanbanBoardBlazor.Server.Dal.Entities.User", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}