using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
    private EditContext cont;
        private bool isVisible;
        private SfKanban<Issue> kanbanRef;
        private KanbanBoardBlazor.Client.Shared.Dialog dialog;
        private List<string> str = new List<string> { "" };
        private List<ColumnModel> cols = new List<ColumnModel>
      {
      new ColumnModel
        {
          KeyField = new List<string>{"Pending" },
          HeaderText = "Pending"
        },
        new ColumnModel
        {
          KeyField = new List<string>{"Ongoing" },
          HeaderText = "Ongoing"
        },
        new ColumnModel
        {
          KeyField = new List<string>{"Complete" },
          HeaderText = "Complete"
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
        id=1,
        stageKey = "Ongoing",
        priority = Priority.CRITICAL,
        title = "Elexus – Update",
        assignees = "ΓΣ, ΧΚ, ΓΠ"

      },
      new Issue
      {
        id=2,
        stageKey = "Ongoing",
        priority = Priority.CRITICAL,
        title = "Gibraltar – Upgrade"

      },
      new Issue
      {
        id=3,
        stageKey = "Ongoing",
        priority = Priority.HIGH,
        title = "Estoril - Government reporting (Slots & Tables)",
        assignees = "ΑΡ, ΒΦ, ΧΠ"
      },new Issue
      {
        id=4,
        stageKey = "Ongoing",
        priority = Priority.HIGH,
        title = "Φορολογικοί – MyDATA"

      }
      ,
      new Issue
      {
        id=5,
        stageKey = "Ongoing",
        priority = Priority.HIGH,
        title = "Boulogne Golden Palace – CRM & Promos Setup",
        assignees = "ΓΣ, ΑΡ, ΧΠ"

      }
      ,new Issue
      {
        id=6,
        stageKey = "Ongoing",
        priority = Priority.HIGH,
        title = "Regency – View Casino Link για MyData",
        assignees = "ΑΡ"

      },new Issue
      {
        id=7,
        stageKey = "Ongoing",
        priority = Priority.HIGH,
        title = "Finix – Include promo packages in Kiosk",
        assignees = "ΑΡ"

      },new Issue
      {
        id=8,
        stageKey = "Complete",
        priority = Priority.LOW,
        title = "P Svilengrad – AML",
        assignees = "ΧΚ, ΓΣ"

      },new Issue
      {
        id=9,
        stageKey = "Ongoing",
        priority = Priority.MEDIUM,
        title = "Maestral – Replace StarGear with StarAgent"

      },new Issue
      {
        id=10,
        stageKey = "Pending",
        priority = Priority.MEDIUM,
        title = "Viva – Dates (Last Visit, κλπ)"

      },new Issue
      {
        id=11,
        stageKey = "Ongoing",
        priority = Priority.MEDIUM,
        title = "Expenses Module"

      },new Issue
      {
        id=12,
        stageKey = "Ongoing",
        priority = Priority.MEDIUM,
        title = "Bi"

      },new Issue
      {
        id=13,
        stageKey = "Ongoing",
        priority = Priority.MEDIUM,
        title = "Εσωτερικές Εκπαιδεύσεις"

      },new Issue
      {
        id=14,
        stageKey = "Pending",
        priority = Priority.MEDIUM,
        title = "Φλώρινα"

      },new Issue
      {
        id=15,
        stageKey = "Pending",
        priority = Priority.MEDIUM,
        title = "ΛΟΥΤΡΑΚΙ – Εγκατάσταση Overview"

      },new Issue
      {
        id=16,
        priority= Priority.MEDIUM,
        stageKey = "Pending",
        title = "Regency – Player Barrings interface with IGT Advantage"

      },new Issue
      {
        id=17,
        priority = Priority.MEDIUM,
        stageKey = "Pending",
        title = "Rocks - Update Startouch"

      },new Issue
      {
        id=18,
        stageKey = "Pending",
        priority = Priority.MEDIUM,
        title = "Estoril – Test of the Integration with government system API"

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

     // dialog.show();
        }

        private void onDialogClose(DialogCloseEventArgs<Issue> args)
        {
      //dialog.issue
      var isValid = cont.Validate();

      if(isValid)
      {
        Console.WriteLine("valid");
      }
      else
      {
        Console.WriteLine("not valid");
        args.Cancel = true;
      }
        }

        private void onDataBound(ActionEventArgs<Issue> args)
        {
            Console.WriteLine(JsonSerializer.Serialize(issues));



            // Console.WriteLine(JsonSerializer.Serialize(project));
            Console.WriteLine(JsonSerializer.Serialize(cols));
        }
    }
}
