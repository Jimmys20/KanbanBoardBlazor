﻿using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Shared
{
    public partial class StageForm
    {
        [Inject]
        StageService stageService { get; set; }

        //[Parameter]
        public Stage stage { get; set; } = new Stage();
        [Parameter]
        public EventCallback<Stage> onSubmit { get; set; }
        //[Parameter]
        public bool Visibility { get; set; } = false;

        public void Show(Stage stage)
        {
            this.stage = stage;
            Visibility = true;
            StateHasChanged();
        }

        private async Task HandleValidSubmit()
        {
            stageService.saveStage(stage);

            Visibility = false;
            await onSubmit.InvokeAsync(stage);
        }
    }
}
