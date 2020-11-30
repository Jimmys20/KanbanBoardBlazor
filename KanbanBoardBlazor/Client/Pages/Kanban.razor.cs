using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Pages
{
    public partial class Kanban
    {
        private bool isVisible;
        private SfKanban<Issue> kanbanRef;
        private KanbanBoardBlazor.Client.Shared.Dialog dialog;
        private List<string> str = new List<string> { "" };
        private List<ColumnModel> cols = new List<ColumnModel>
      {
      new ColumnModel
        {
          KeyField = new List<string>{"Open" },
          HeaderText = "XXXXXX"
        },
        new ColumnModel
        {
          KeyField = new List<string>{"Closed" },
          HeaderText = "eeee"
        },
        new ColumnModel
        {
          KeyField = new List<string>{"datata" },
          HeaderText = "bbbb"
        }
      };
        private Project project = new Project()
        {
            stages = new List<Stage>
      {
        new Stage
        {
          key = "Open",
          title = "XXXXXX"
        },
        new Stage
        {
          key = "Closed",
          title = "eeee"
        },
        new Stage
        {
          key = "datata",
          title = "bbbb"
        }
      }
        };
        private List<Issue> issues = new List<Issue>()
    {
      new Issue
      {
        id=111,
        stageKey = "datata",
        title = "Fix this fast"

      }
    };
        //public List<Issue> issues => new List<Issue>
        //    {
        //      new Issue
        //      {
        //        priority = Priority.LOW,
        //        title = "Issue 1",
        //        assignee = "Backlog",
        //        stageId = 0,
        //        stage = new Stage
        //        {
        //          title = "Backlog"
        //        }
        //      },
        //      new Issue
        //      {
        //        priority = Priority.HIGH,
        //        title = "Issue 2",
        //        assignee = "Backlog",
        //        stageId = 1,
        //        stage = new Stage
        //        {
        //          title = "Backlog"
        //        }
        //      },
        //      new Issue
        //      {
        //        priority = Priority.CRITICAL,
        //        title = "Issue 3",assignee = "Backlog",
        //        stageId = 2,
        //        stage = new Stage
        //        {
        //          title = "Backlog"
        //        }
        //      }
        //    };

        //protected override void OnInitialized()
        //{
        //  project = projectService.getProjectById();
        //}
        private void showAddCardDialog()
        {
            kanbanRef.OpenDialog(CurrentAction.Add, new Issue());

            //  kanbanRef.add
        }

        private void addNewColumn()
        {
            //project.stages.Add(new Stage
            //{
            //  key = "klidi",
            //  title = "titlos"
            //});
            //cols.Add(new ColumnModel
            //{
            //  HeaderText = "afafa",
            //  KeyField = new List<string> { "fff" }


            //});
            kanbanRef.AddColumn(new ColumnModel
            {
                HeaderText = "afafa",
                KeyField = new List<string> { "fff" }


            }, project.stages.Count);
            //StateHasChanged();
        }

        private void onDialogOpen(DialogOpenEventArgs<Issue> args)
        {
            args.Cancel = true;
            isVisible = true;
        }

        private void onDialogClose(DialogCloseEventArgs<Issue> args)
        {
            //dialog.issue
        }

        private void onDataBound(ActionEventArgs<Issue> args)
        {
            Console.WriteLine(JsonSerializer.Serialize(issues));



            // Console.WriteLine(JsonSerializer.Serialize(project));
            Console.WriteLine(JsonSerializer.Serialize(cols));
        }
    }
}
