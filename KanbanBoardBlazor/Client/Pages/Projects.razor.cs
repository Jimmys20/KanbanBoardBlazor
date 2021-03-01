using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Pages
{
  public partial class Projects
  {
    [Inject] private ProjectService projectService { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    private List<ProjectDto> projects = new List<ProjectDto>();

    protected override async Task OnInitializedAsync()
    {
      projects = await projectService.getProjects(); 
    }

    private void SelectedProject(long projectId)
    {
      NavigationManager.NavigateTo($"kanban/{projectId}");
    }

  }
}
