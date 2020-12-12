using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal
{
    public class IssueTrackerDbContext : DbContext
    {
        public IssueTrackerDbContext(DbContextOptions<IssueTrackerDbContext> options) : base(options) 
        {
        }

        public DbSet<Project> projects { get; set; }
        public DbSet<Stage> stages { get; set; }
        public DbSet<Issue> issues { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set a default schema for ALL tables
            modelBuilder.HasDefaultSchema(Constants.SCHEMA);
        }
    }
}
