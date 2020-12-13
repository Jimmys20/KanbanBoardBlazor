using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Issue> Issues { get; set; }
        //public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<IssueTag> IssueTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("ISSUE_TRACKER");
            modelBuilder.HasDefaultSchema("PANAGIOTIS");

            modelBuilder.Entity<Assignment>().HasKey(a => new { a.IssueId, a.UserId });
            modelBuilder.Entity<IssueTag>().HasKey(it => new { it.IssueId, it.TagId });

            //    .WithMany()
        }
    }
}
