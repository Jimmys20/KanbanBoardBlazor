using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Client.Shared;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
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
        [Inject] private ProjectService projectService { get; set; }
        [Inject] private IssueService issueService { get; set; }
        [Inject] private UserService userService { get; set; }

        private Project project;
        private SfKanban<Issue> kanbanRef;
        private List<User> users;

        private SfTextBox titleRef;
        private SfDatePicker<DateTime?> deadlineRef;
        private SfDropDownList<Priority, string> priorityRef;
        private SfTextBox descriptionRef;
        private SfMultiSelect<List<long>> assigneesRef;

        protected override async Task OnInitializedAsync()
        {
            project = await projectService.getProjectById(100);
            users = await userService.getAllUsers();
        }

        private async void onDialogClose(DialogCloseEventArgs<Issue> args)
        {
            if (args.Interaction != "Cancel" && args.Interaction != "Close")
            {
                if (args.RequestType == CurrentAction.Edit)
                {
                    Issue issue = args.Data;

                    issue.title = titleRef.Value;
                    issue.deadline = deadlineRef.Value;
                    issue.description = descriptionRef.Value;
                    issue.priority = priorityRef.Value;
                    //issue.assignees = users.Where(u => assigneesRef.Value.Contains(u.userId)).ToList();

                    await kanbanRef.UpdateCard(issue);
                }
                else if (args.RequestType == CurrentAction.Add)
                {
                    var t = args.Data;

                    Issue issue = new Issue
                    {
                        title = titleRef.Value,
                        deadline = deadlineRef.Value,
                        description = descriptionRef.Value,
                        priority = priorityRef.Value//,
                        //assignees = users.Where(u => assigneesRef.Value.Contains(u.userId)).ToList()
                    };
                    await kanbanRef.AddCard(issue);
                }
            }
            else
            {
                args.Cancel = true;
            }
        }

        private void showAddCardDialog()
        {
            Issue issue = new Issue
            {
                
            };
            kanbanRef.OpenDialog(CurrentAction.Add, issue);
        }

        private async Task onActionCompleteAsync(ActionEventArgs<Issue> args)
        {
            //Console.WriteLine(JsonSerializer.Serialize(args));

            //Console.WriteLine(JsonSerializer.Serialize(project.issues));

            //await projectService.save(project);

            //foreach (var issue in args.ChangedRecords)
            //{
            //    await issueService.Update(issue);
            //}

            //foreach (var issue in args.DeletedRecords)
            //{
            //    await issueService.Delete(issue.issueId);
            //}
        }

        //StageForm stageForm;


        //private bool isAddColumnDialogVisible;








        //private SfDataManager manager;
        //private EditContext cont;
        //private bool isVisible;

        //private DetailsDialog dialog;



        //private void showAddColumnDialog()
        //{
        //    //isAddColumnDialogVisible = true;
        //    var stage = new Stage();
        //    stageForm.Show(stage);
        //}

        //private void onSubmit(Stage stage)
        //{
        //    //stage.key = "test";
        //    //cols.Add(new ColumnModel
        //    //{
        //    //    HeaderText = stage.title,
        //    //    KeyField = new List<string> { stage.key }
        //    //});
        //   // kanbanRef.Refresh();
        //  //  StateHasChanged();


        //    //kanbanRef.AddColumn(new ColumnModel
        //    //{
        //    //    HeaderText = stage.title,
        //    //    KeyField = new List<string> { stage.key }
        //    //}, new Random().Next(0, cols.Count));
        //}




        //private void updateCard()
        //{
        //    //var issue = issues[0];
        //    //issue.title = "UPDATED";
        //}

        //private async Task showAddCardDialog()
        //{
        //    //kanbanRef.OpenDialog(CurrentAction.Add, new Issue());
        //    //var issue = new Issue
        //    //{
        //    //    title = "New task",
        //    //    priority = Priority.MEDIUM,
        //    //    stageKey = "Backlog"
        //    //};

        //    //var issueId = await issueService.insertIssue(issue);

        //    //if (issueId > 0)
        //    //{
        //    //    issue.id = issueId;
        //    //    await kanbanRef.AddCard(issue);
        //    //    Console.WriteLine(JsonSerializer.Serialize(issues));
        //    //}
        //    //  kanbanRef.add
        //}

        //private void addNewColumn()
        //{
        //    //project.stages.Add(new Stage
        //    //{
        //    //  key = "klidi",
        //    //  title = "titlos"
        //    //});
        //    //cols.Add(new ColumnModel
        //    //{
        //    //  HeaderText = "afafa",
        //    //  KeyField = new List<string> { "fff" }


        //    //});
        //    kanbanRef.AddColumn(new ColumnModel
        //    {
        //        HeaderText = "afafa",
        //        KeyField = new List<string> { "fff" }


        //    }, project.stages.Count);
        //    //StateHasChanged();
        //}

        //private void onDialogOpen(DialogOpenEventArgs<Issue> args)
        //{
        //    args.Cancel = true;

        //    // dialog.show();
        //}

        //private void onCardClick(CardClickEventArgs<Issue> args)
        //{
        //    dialog.show(args.Data);
        //}

        //private void onDialogClose(DialogCloseEventArgs<Issue> args)
        //{
        //    //dialog.issue
        //    var isValid = cont.Validate();

        //    if (isValid)
        //    {
        //        Console.WriteLine("valid");
        //    }
        //    else
        //    {
        //        Console.WriteLine("not valid");
        //        args.Cancel = true;
        //    }
        //}

        //private void onDataBound(ActionEventArgs<Issue> args)
        //{
        //    //Console.WriteLine(JsonSerializer.Serialize(issues));



        //    // Console.WriteLine(JsonSerializer.Serialize(project));
        //    //Console.WriteLine(JsonSerializer.Serialize(cols));
        //}
    }
}
