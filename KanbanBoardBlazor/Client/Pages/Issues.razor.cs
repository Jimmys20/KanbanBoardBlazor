using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Pages
{
    public partial class Issues
    {
        [Inject] private IssueService issueService { get; set; }

        private List<IssueDto> issues;
        private List<IssueDto> chosenissues = new List<IssueDto>();
        private List<IssueDto> openissues = new List<IssueDto>();
        private List<IssueDto> closedissues = new List<IssueDto>();

        private int openCount;
        private int closedCount;

        protected override async Task OnInitializedAsync()
        {
            issues = await issueService.GetIssues();
            openissues = issues.Where(i => i.IsOpen == true).ToList();
            closedissues = issues.Where(i => i.IsOpen == false).ToList();

            chosenissues = openissues;

            openCount = openissues.Count;
            closedCount = closedissues.Count;
        }

        public void OnOpenTabClicked()
        {
            chosenissues = openissues;
        }

        public void OnCloseTabClicked()
        {
            chosenissues = closedissues;
        }
    }
}
