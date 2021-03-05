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
using Syncfusion.Blazor.RichTextEditor;
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
        [Inject] private TagService tagService { get; set; }
        [Inject] private CustomerService customerService { get; set; }
        [Inject] private ApplicationService applicationService { get; set; }

        [Parameter]
        public long projectId { get; set; }

        private ProjectDto project;
        //private List<IssueDto> issues;
        private SfKanban<IssueDto> kanbanRef;
        private Query query = new Query();
        private List<UserDto> users;
        private List<TagDto> tags;
        private List<CustomerDto> customers;
        private List<ApplicationDto> applications;

        private SfTextBox titleRef;
        private SfDatePicker<DateTime?> deadlineRef;
        private SfDropDownList<Priority, string> priorityRef;
        private SfDropDownList<long?, ApplicationDto> applicationRef;
        //private SfRichTextEditor descriptionRef;
        private SfTextBox descriptionRef;
        //private string description;
        //private SfMultiSelect<List<long>> assigneesRef;
        private List<long> selectedAssignees = new List<long>();
        //private SfMultiSelect<List<long>> tagsRef;
        private List<long> selectedTags = new List<long>();
        //private SfMultiSelect<List<long>> customersRef;
        private List<long> selectedCustomers = new List<long>();

        private WhereFilter assigneesFilter;
        private WhereFilter customersFilter;
        private WhereFilter applicationFilter;

        protected override async Task OnInitializedAsync()
        {
            project = await projectService.getProjectById(projectId);
            users = await userService.getAllUsers();
            tags = await tagService.getAllTags();
            customers = await customerService.getAllCustomers();
            applications = await applicationService.getAllApplications();
        }

        private void OnDialogOpen(DialogOpenEventArgs<IssueDto> args)
        {
            var issue = args.Data;

            if (issue.Assignees != null && issue.Assignees.Any())
            {
                selectedAssignees = issue.Assignees.Select(a => a.UserId).ToList();
            }
            else
            {
                selectedAssignees = new List<long>();
            }

            if (issue.Tags != null && issue.Tags.Any())
            {
                selectedTags = issue.Tags.Select(a => a.TagId).ToList();
            }
            else
            {
                selectedTags = new List<long>();
            }

            if (issue.Customers != null && issue.Customers.Any())
            {
                selectedCustomers = issue.Customers.Select(a => a.CustomerId).ToList();
            }
            else
            {
                selectedCustomers = new List<long>();
            }

            //if (!string.IsNullOrEmpty(issue.Description))
            //{
            //    description = issue.Description;
            //}
            //else
            //{
            //    description = string.Empty;
            //}
        }

        private async void onDialogClose(DialogCloseEventArgs<IssueDto> args)
        {

            if (args.Interaction != "Cancel" && args.Interaction != "Close")
            {
                if (args.RequestType == CurrentAction.Edit)
                {
                    IssueDto issue = args.Data;

                    issue.Title = titleRef.Value;
                    issue.Deadline = deadlineRef.Value;
                    issue.Description = descriptionRef.Value;
                    issue.Priority = priorityRef.Value;
                    issue.ApplicationId = applicationRef.Value;
                    issue.Application = applications.FirstOrDefault(a => a.ApplicationId == applicationRef.Value);
                    if (selectedAssignees != null)
                    {
                        issue.Assignees = users.Where(u => selectedAssignees.Contains(u.UserId)).ToList();
                    }
                    else
                    {
                        issue.Assignees = null;
                    }

                    if (selectedTags != null)
                    {
                        issue.Tags = tags.Where(u => selectedTags.Contains(u.TagId)).ToList();
                    }
                    else
                    {
                        issue.Tags = null;
                    }

                    if (selectedCustomers != null)
                    {
                        issue.Customers = customers.Where(u => selectedCustomers.Contains(u.CustomerId)).ToList();
                    }
                    else
                    {
                        issue.Customers = null;
                    }
                    //await kanbanRef.UpdateCard(issue);
                }
                else if (args.RequestType == CurrentAction.Add)
                {
                    IssueDto issue = args.Data;

                    issue.Title = titleRef.Value;
                    issue.Deadline = deadlineRef.Value;
                    issue.Description = descriptionRef.Value;
                    issue.Priority = priorityRef.Value;
                    issue.ApplicationId = applicationRef.Value;
                    issue.Application = applications.FirstOrDefault(a => a.ApplicationId == applicationRef.Value);
                    if (selectedAssignees != null)
                    {
                        issue.Assignees = users.Where(u => selectedAssignees.Contains(u.UserId)).ToList();
                    }
                    else
                    {
                        issue.Assignees = null;
                    }

                    if (selectedTags != null)
                    {
                        issue.Tags = tags.Where(u => selectedTags.Contains(u.TagId)).ToList();
                    }
                    else
                    {
                        issue.Tags = null;
                    }

                    if (selectedCustomers != null)
                    {
                        issue.Customers = customers.Where(u => selectedCustomers.Contains(u.CustomerId)).ToList();
                    }
                    else
                    {
                        issue.Customers = null;
                    }
                    //var t = args.Data;

                    //Issue issue = new Issue
                    //{
                    //    title = titleRef.Value,
                    //    deadline = deadlineRef.Value,
                    //    description = descriptionRef.Value,
                    //    priority = priorityRef.Value,
                    //    assignees = users.Where(u => assigneesRef.Value.Contains(u.userId)).ToList()
                    //};
                    //await kanbanRef.AddCard(issue);
                }

            }

        }

        private void showAddCardDialog()
        {
            IssueDto issue = new IssueDto
            {
                StageKey = project.stages.OrderBy(s => s.Position).FirstOrDefault()?.StageKey,
                ProjectId = project.projectId
            };
            kanbanRef.OpenDialog(CurrentAction.Add, issue);
        }

        private async void onActionComplete(ActionEventArgs<IssueDto> args)
        {
            Console.WriteLine(JsonSerializer.Serialize(args));

            //Console.WriteLine(JsonSerializer.Serialize(project.issues));

            //await projectService.save(project);

            foreach (var issue in args.AddedRecords ?? Enumerable.Empty<IssueDto>())
            {
                var createdIssue = await issueService.Create(issue);

                issue.IssueId = createdIssue.IssueId;
                issue.CreatedAt = createdIssue.CreatedAt;

                kanbanRef.Refresh();
            }

            foreach (var issue in args.ChangedRecords ?? Enumerable.Empty<IssueDto>())
            {
                var updatedIssue = await issueService.Update(issue);

                issue.UpdatedAt = updatedIssue.UpdatedAt;
            }

            foreach (var issue in args.DeletedRecords ?? Enumerable.Empty<IssueDto>())
            {
                await issueService.Delete(issue.IssueId);
            }
        }

        //private void onValueSelect(CustomValueEventArgs args)
        //{
        //    Console.WriteLine(JsonSerializer.Serialize(args));
        //}

        //private SfMultiSelect<long> AssigneesQuery;

        private void OnAssigneesQueryUpdate(MultiSelectChangeEventArgs<List<long>> args)
        {
            if (args.Value == null || !args.Value.Any())
            {
                assigneesFilter = null;
            }
            else
            {
                var filters = new List<WhereFilter>();
                
                foreach (var value in args.Value)
                {
                    filters.Add(new WhereFilter
                    {
                        Field = "AssigneesStr",
                        Operator = "contains",
                        value = value
                    });
                }

                assigneesFilter = WhereFilter.Or(filters);
            }

            UpdateQuery();
        }

        private void OnCustomersQueryUpdate(MultiSelectChangeEventArgs<List<long>> args)
        {
            if (args.Value == null || !args.Value.Any())
            {
                customersFilter = null;
            }
            else
            {
                var filters = new List<WhereFilter>();

                foreach (var value in args.Value)
                {
                    filters.Add(new WhereFilter
                    {
                        Field = "CustomersStr",
                        Operator = "contains",
                        value = value
                    });
                }

                customersFilter = WhereFilter.Or(filters);
            }

            UpdateQuery();
        }

        private void OnApplicationQueryUpdate(ChangeEventArgs<long?, ApplicationDto> args)
        {
            if (args.Value == null)
            {
                applicationFilter = null;
            }
            else
            {
                applicationFilter = new WhereFilter
                {
                    Field = "ApplicationId",
                    Operator = "equals",
                    value = args.Value
                };
            }

            UpdateQuery();
        }

        private void UpdateQuery()
        {
            //if (args.Value == null || !args.Value.Any())
            //{
            //    query = new Query();
            //}
            //else
            //{
            //    //query = new Query();
            //    List<WhereFilter> filters = new List<WhereFilter>();
            //    foreach (var value in args.Value)
            //    {
            //        //query = query.Where(new WhereFilter
            //        //{
            //        //    Field = "AssigneesStr",
            //        //    Operator = "contains",
            //        //    value = value

            //        //});

            //        filters.Add(new WhereFilter
            //        {
            //            Field = "AssigneesStr",
            //            Operator = "contains",
            //            value = value
            //        });
            //    }

            //    var filter = WhereFilter.Or(filters);

            //    query = new Query().Where(filter);
            //}
            if (customersFilter == null && assigneesFilter == null
                && applicationFilter == null)
            {
                query = new Query();
            }
            else
            {
                var filters = new List<WhereFilter>();

                if (customersFilter != null)
                {
                    filters.Add(customersFilter);
                }

                if (assigneesFilter != null)
                {
                    filters.Add(assigneesFilter);
                }

                if (applicationFilter != null)
                {
                    filters.Add(applicationFilter);
                }

                var filter = WhereFilter.And(filters);

                query = new Query().Where(filter);
            }
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
