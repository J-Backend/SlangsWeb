using Microsoft.AspNetCore.Components;
using SlangModels.Dtos;
using SlangsWeb.Services.Contracts;

namespace SlangsWeb.Pages.Components
{
    public partial class AddEdit : ComponentBase
    {
        SlangDto model = new SlangDto();
        [Parameter]
        public int Id { get; set; } = 0;
        [Inject]
        public NavigationManager Navigator { get; set; }
        [Inject]
        public ISlangService SlangService { get; set; }


        protected async override Task OnInitializedAsync()
        {

            if (Id != 0)
            {
                var modelEdit = await this.SlangService.GetSlangById(Id);
                model = modelEdit;

            }


        }

        public async Task AddNewSlang()
        {
            var newSlang = new NewSlangDto()
            {
                Phrase = this.model.Phrase,
                Meaning = this.model.Meaning,
            };
            var state = await this.SlangService.AddSlang(newSlang);

            if (state == 1)
            {
                Navigator.NavigateTo("/slang");
            }
            return;
        }

        public async Task EditAsync()
        {

            var state = await this.SlangService.UpdateSlang(model);
            if (state == 1)
            {
                Navigator.NavigateTo("/slang");
            }
            return;
        }
    }
}
