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
        public static void initialize(AppDbContext context)
        {
            context.Database.EnsureDeleted(new string[] { "PANAGIOTIS" });
            context.Database.EnsureCreated(new string[] { "PANAGIOTIS" });

            var users = new List<User>
                {
                    new User {LastName="Μαραγκός", FirstName="Δημήτρης"},
                    new User {LastName="Πιπερόπουλος", FirstName="Παναγιώτης"},
                    new User {LastName="Κρίτου", FirstName="Μαρία"},
                    new User {LastName="Πατρίκιος", FirstName="Γιώργος"},
                    new User {LastName="Σεϊτανίδης", FirstName="Γιώργος"},
                    new User {LastName="Φωκιανός", FirstName="Βαγγέλης"},
                    new User {LastName="Κατσάδας", FirstName="Βαγγέλης"},
                    new User {LastName="Παυλίδης", FirstName="Χρόνης"},
                    new User {LastName="Ράπτης", FirstName="Άκης"},
                    new User {LastName="Καρυπίδης", FirstName="Χριστόφορος"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"},
                    //new UserEntity {lastName="Μαραγκός", firstName="Δημήτρης"}
                };

            context.Users.AddRange(users);
            context.SaveChanges();


            var issues = new List<Issue>
        {
          new Issue
          {
            Priority = Priority.LOW,
            Title = "Issue 1"
          },
          new Issue
          {
            Priority = Priority.HIGH,
            Title = "Issue 2"
          },
          new Issue
          {
            Priority = Priority.CRITICAL,
            Title = "Issue 3"
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

            context.Issues.AddRange(issues);
            context.SaveChanges();

            var board = new Project
            {
                ProjectId = 100,
                Name = "KanbanBoard",
                Stages = new List<Stage>
          {
            new Stage
            {
                Position = 0,
              Title = "Backlog",
              Color = "cyan",
              Issues = new List<Issue>
              {
                new Issue
                {
                    ProjectId = 100,
                  IssueId = 100,
                  Title = "MongoDB Migrations",

                  Deadline = DateTime.Now.AddYears(2),
                  Priority = Priority.LOW,
                  IssueTags = new List<IssueTag>
                  {
                      new IssueTag
                      {
                          Tag = new Tag
                          {
                              Text = "Development",
                              CssClass = "navy white"
                          }
                      },
                      new IssueTag
                      {
                          Tag = new Tag
                          {
                              Text = "Support",
                              CssClass = "lime black"
                          }
                      }
                  }
                },
                new Issue
                {
                    ProjectId = 100,
                  Title = "Rotation Curson: Needs White Border",

                  Deadline = DateTime.Now.AddMonths(6),
                  Priority = Priority.MEDIUM
                }
              }
            },
            new Stage
            {
                Position = 2,
              Title = "In progress",
              Color = "magenta",
              Issues = new List<Issue>
              {
                new Issue
                {
                    ProjectId = 100,
                  Title = "Page Settings does not respect Command+Z",

                  Deadline = DateTime.Now.AddMonths(3),
                  Priority = Priority.HIGH

                },
                new Issue
                {
                    ProjectId = 100,
                  Title = "Grid doesn't respect page size",

                  Deadline = DateTime.Now.AddDays(21),
                  Priority = Priority.CRITICAL//,
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
                Position = 1,
              Title = "Done",
              Color = "yellow",
              Issues = new List<Issue>
              {
                new Issue
                {
                    ProjectId = 100,
                  Title = "Preview of page does not be updated after change page size name",

                  Deadline = DateTime.Now.AddDays(14),
                  Priority = Priority.MEDIUM,
                  IsOpen = true
                },
                new Issue
                {
                    ProjectId = 100,
                  Title = "User changes width/height: pages size not saved",

                  Deadline = DateTime.Now.AddDays(6),
                  Priority = Priority.HIGH,
                  IsOpen = true
                }
              }
            }
          }
            };

            context.Projects.Add(board);
            context.SaveChanges();

            var projects = new List<Project>
        {
          new Project
          {
            Name = "Overview"
          },
          new Project
          {
            Name = "CasinoCRM"
          },
          new Project
          {
            Name = "StarTouch"
          }
        };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
        
    }
}
