using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Shared;
using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal
{
    public static class DbInitializer
    {
        public static void initialize(ISQWWorker worker)
        {
            worker.run(context =>
            {
                try { context.execute($"CREATE SEQUENCE {Constants.SCHEMA}.SEQ_PROJECT"); } catch (Exception) { }
                try { context.execute($"CREATE SEQUENCE {Constants.SCHEMA}.SEQ_STAGE"); } catch (Exception) { }
                try { context.execute($"CREATE SEQUENCE {Constants.SCHEMA}.SEQ_ISSUE"); } catch (Exception) { }

                context.createTable(typeof(ProjectEntity), true);
                context.createTable(typeof(StageEntity), true);
                context.createTable(typeof(IssueEntity), true);
                context.createTable(typeof(AssignmentEntity), true);

                var issues = new List<IssueEntity>
        {
          new IssueEntity
          {
            priority = Priority.LOW,
            title = "Issue 1"
          },
          new IssueEntity
          {
            priority = Priority.HIGH,
            title = "Issue 2"
          },
          new IssueEntity
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

                context.save(issues);

                var board = new ProjectEntity
                {
                    projectId = 100,
                    name = "KanbanBoard",
                    stages = new List<StageEntity>
          {
            new StageEntity
            {
                position = 0,
              title = "Backlog",
              color = "cyan",
              issues = new List<IssueEntity>
              {
                new IssueEntity
                {
                    projectId = 100,
                  issueId = 100,
                  title = "MongoDB Migrations",
                  assignee = "Panagiotis",
                  deadline = DateTime.Now.AddYears(2),
                  priority = Priority.LOW
                },
                new IssueEntity
                {
                    projectId = 100,
                  title = "Rotation Curson: Needs White Border",
                  assignee = "Dimitris",
                  deadline = DateTime.Now.AddMonths(6),
                  priority = Priority.MEDIUM
                }
              }
            },
            new StageEntity
            {
                position = 2,
              title = "In progress",
              color = "magenta",
              issues = new List<IssueEntity>
              {
                new IssueEntity
                {
                    projectId = 100,
                  title = "Page Settings does not respect Command+Z",
                  assignee = "Maria",
                  deadline = DateTime.Now.AddMonths(3),
                  priority = Priority.HIGH

                },
                new IssueEntity
                {
                    projectId = 100,
                  title = "Grid doesn't respect page size",
                  assignee = "Panagiotis",
                  deadline = DateTime.Now.AddDays(21),
                  priority = Priority.CRITICAL,
                  assignees = new List<UserEntity>
                  {
                      new UserEntity
                      {
                          username = "jim"
                      }
                  }
                }
              }
            },
            new StageEntity
            {
                position = 1,
              title = "Done",
              color = "yellow",
              issues = new List<IssueEntity>
              {
                new IssueEntity
                {
                    projectId = 100,
                  title = "Preview of page does not be updated after change page size name",
                  assignee = "Dimitris",
                  deadline = DateTime.Now.AddDays(14),
                  priority = Priority.MEDIUM,
                  isOpen = true
                },
                new IssueEntity
                {
                    projectId = 100,
                  title = "User changes width/height: pages size not saved",
                  assignee = "Maria",
                  deadline = DateTime.Now.AddDays(6),
                  priority = Priority.HIGH,
                  isOpen = true
                }
              }
            }
          }
                };

                context.save(board);

                var projects = new List<ProjectEntity>
        {
          new ProjectEntity
          {
            name = "Overview"
          },
          new ProjectEntity
          {
            name = "CasinoCRM"
          },
          new ProjectEntity
          {
            name = "StarTouch"
          }
        };

                context.save(projects);
            });
        }
    }
}
