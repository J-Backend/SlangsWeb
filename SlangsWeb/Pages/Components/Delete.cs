using Microsoft.AspNetCore.Components;
using SlangsWeb.Services.Contracts;

namespace SlangsWeb.Pages.Components
{
    public partial class Delete : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ISlangService SlangService { get; set; }

        [Inject]
        public NavigationManager Navigator { get; set; }

        public async Task DeleteAsync(int id)
        {
            var state = await this.SlangService.DeleteSlang(id);
            if (state == 1)
            {
                Navigator.NavigateTo("/slang");
            }
            return;
        }
    }
}
