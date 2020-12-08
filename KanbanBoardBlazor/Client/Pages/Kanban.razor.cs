using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Client.Shared;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Data;
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
        StageForm stageForm;


        private bool isAddColumnDialogVisible;

        [Inject]
        private IssueService issueService { get; set; }
        [Inject]
        private ProjectService projectService { get; set; }
        


        private SfDataManager manager;
        private EditContext cont;
        private bool isVisible;
        private SfKanban<Issue> kanbanRef;
        private DetailsDialog dialog;
       
       
        private Project project;


        protected override async Task OnInitializedAsync()
        {
            isAddColumnDialogVisible = false;

            //await base.OnInitializedAsync();
            //Console.WriteLine("gegws");
            project = await projectService.getProjectById(100);

            //Console.WriteLine(JsonSerializer.Serialize(issues));

            //foreach(var issue in issues2)
            //{
            //    await kanbanRef.AddCard(new Issue());
            //}
            //kanbanRef.Refresh();
            //kanbanRef.DataSource = issues;
            //StateHasChanged();
            //kanbanRef.Refresh();
        }

        private void showAddColumnDialog()
        {
            //isAddColumnDialogVisible = true;
            var stage = new Stage();
            stageForm.Show(stage);
        }

        private void onSubmit(Stage stage)
        {
            //stage.key = "test";
            //cols.Add(new ColumnModel
            //{
            //    HeaderText = stage.title,
            //    KeyField = new List<string> { stage.key }
            //});
           // kanbanRef.Refresh();
          //  StateHasChanged();
           
            
            //kanbanRef.AddColumn(new ColumnModel
            //{
            //    HeaderText = stage.title,
            //    KeyField = new List<string> { stage.key }
            //}, new Random().Next(0, cols.Count));
        }




        private void updateCard()
        {
            //var issue = issues[0];
            //issue.title = "UPDATED";
        }

        private async Task showAddCardDialog()
        {
            //kanbanRef.OpenDialog(CurrentAction.Add, new Issue());
            //var issue = new Issue
            //{
            //    title = "New task",
            //    priority = Priority.MEDIUM,
            //    stageKey = "Backlog"
            //};

            //var issueId = await issueService.insertIssue(issue);

            //if (issueId > 0)
            //{
            //    issue.id = issueId;
            //    await kanbanRef.AddCard(issue);
            //    Console.WriteLine(JsonSerializer.Serialize(issues));
            //}
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

        private void onCardClick(CardClickEventArgs<Issue> args)
        {
            dialog.show(args.Data);
        }

        private void onDialogClose(DialogCloseEventArgs<Issue> args)
        {
            //dialog.issue
            var isValid = cont.Validate();

            if (isValid)
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
            //Console.WriteLine(JsonSerializer.Serialize(issues));



            // Console.WriteLine(JsonSerializer.Serialize(project));
            //Console.WriteLine(JsonSerializer.Serialize(cols));
        }
    }
}
