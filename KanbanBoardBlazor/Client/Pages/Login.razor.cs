using KanbanBoardBlazor.Client.Services;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Pages
{
    public partial class Login
    {
        [Inject]
        private UserService userService { get; set; }
        [Inject]
        private CustomAuthStateProvider authStateProvider { get; set; }
        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Parameter]
        public string ReturnUrl { get; set; }

        private LoginInputModel credentials = new LoginInputModel();

        private async Task HandleValidSubmit()
        {
            var token = await userService.Login(credentials);

            if (!string.IsNullOrEmpty(token))
            {
                await authStateProvider.SetTokenAsync(token);
                credentials = new LoginInputModel();

                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    navigationManager.NavigateTo(string.Empty);
                }
                else
                {
                    navigationManager.NavigateTo(ReturnUrl);
                }
            }
        }
    }
}
