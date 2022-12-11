using Kasa.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

namespace Kasa.Web.Pages.Devices
{
    public class DevicesComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected List<DeviceViewModel> Devices = new List<DeviceViewModel>();
        
        [Inject]
        protected HttpClient httpClient { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            Devices = await httpClient.GetFromJsonAsync<List<DeviceViewModel>>("webapi/periodictable");
        }
    }
}
