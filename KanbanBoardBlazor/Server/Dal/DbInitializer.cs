using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal
{
    public static class DbInitializer
    {
        public static void initialize(IssueTrackerDbContext context)
        {
            context.Database.EnsureDeleted(new string[] { "PANAGIOTIS" });
            context.Database.EnsureCreated(new string[] { "PANAGIOTIS" });

            var users = new List<User>
                {
                    new User {lastName="Μαραγκός", firstName="Δημήτρης"},
                    new User {lastName="Πιπερόπουλος", firstName="Παναγιώτης"},
                    new User {lastName="Κρίτου", firstName="Μαρία"},
                    new User {lastName="Πατρίκιος", firstName="Γιώργος"},
                    new User {lastName="Σεϊτανίδης", firstName="Γιώργος"},
                    new User {lastName="Φωκιανός", firstName="Βαγγέλης"},
                    new User {lastName="Κατσάδας", firstName="Βαγγέλης"},
                    new User {lastName="Παυλίδης", firstName="Χρόνης"},
                    new User {lastName="Ράπτης", firstName="Άκης"},
                    new User {lastName="Καρυπίδης", firstName="Χριστόφορος"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"}
                };

            context.users.AddRange(users);
            context.SaveChanges();


            var issues = new List<Issue>
        {
          new Issue
          {
            priority = Priority.LOW,
            title = "Issue 1"
          },
          new Issue
          {
            priority = Priority.HIGH,
            title = "Issue 2"
          },
          new Issue
          {
            priority = Priority.CRITICAL,
            title = "Issue 3"
          }
        };

            //for (var i = 100; i < 200; i++)
            //{
            //  issues.Add(new Issue
            //  {
            //    title = "Issue " + i,
            //    priority = Priority.MEDIUM
            //  });
            //}

            context.issues.AddRange(issues);
            context.SaveChanges();

            var board = new Project
            {
                projectId = 100,
                name = "KanbanBoard",
                stages = new List<Stage>
          {
            new Stage
            {
                position = 0,
              title = "Backlog",
              color = "cyan",
              issues = new List<Issue>
              {
                new Issue
                {
                    projectId = 100,
                  issueId = 100,
                  title = "MongoDB Migrations",

                  deadline = DateTime.Now.AddYears(2),
                  priority = Priority.LOW
                },
                new Issue
                {
                    projectId = 100,
                  title = "Rotation Curson: Needs White Border",

                  deadline = DateTime.Now.AddMonths(6),
                  priority = Priority.MEDIUM
                }
              }
            },
            new Stage
            {
                position = 2,
              title = "In progress",
              color = "magenta",
              issues = new List<Issue>
              {
                new Issue
                {
                    projectId = 100,
                  title = "Page Settings does not respect Command+Z",

                  deadline = DateTime.Now.AddMonths(3),
                  priority = Priority.HIGH

                },
                new Issue
                {
                    projectId = 100,
                  title = "Grid doesn't respect page size",

                  deadline = DateTime.Now.AddDays(21),
                  priority = Priority.CRITICAL//,
                  //assignees = new List<UserEntity>
                  //{
                  //    new UserEntity
                  //    {
                  //        lastName = "jim"
                  //    }
                  //}
                }
              }
            },
            new Stage
            {
                position = 1,
              title = "Done",
              color = "yellow",
              issues = new List<Issue>
              {
                new Issue
                {
                    projectId = 100,
                  title = "Preview of page does not be updated after change page size name",

                  deadline = DateTime.Now.AddDays(14),
                  priority = Priority.MEDIUM,
                  isOpen = true
                },
                new Issue
                {
                    projectId = 100,
                  title = "User changes width/height: pages size not saved",

                  deadline = DateTime.Now.AddDays(6),
                  priority = Priority.HIGH,
                  isOpen = true
                }
              }
            }
          }
            };

            context.projects.Add(board);
            context.SaveChanges();

            var projects = new List<Project>
        {
          new Project
          {
            name = "Overview"
          },
          new Project
          {
            name = "CasinoCRM"
          },
          new Project
          {
            name = "StarTouch"
          }
        };

            context.projects.AddRange(projects);
            context.SaveChanges();
        }
        
    }
}
