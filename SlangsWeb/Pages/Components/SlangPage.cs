using Microsoft.AspNetCore.Components;
using SlangModels.Dtos;
using SlangsWeb.Services.Contracts;
using Toolbelt.Blazor.SpeechSynthesis;

namespace SlangsWeb.Pages.Components
{
    public partial class SlangPage : ComponentBase
    {
        public int TotalSlangs { get; set; }
        public string Phrase { get; set; }
        public string Meaning { get; set; }

        [Inject]
        public NavigationManager Navigator { get; set; }

        //private readonly ISlangService slangService;

        public IEnumerable<SlangDto> ListSlangs { get; set; }

        private IEnumerable<SpeechSynthesisVoice> Voices;

        [Inject]
        public ISlangService SlangService { get; set; }

        [Inject]
        public SpeechSynthesis SpeechSynthesis { get; set; }
        protected override async Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();
            
            await GetListSlangs(1);
            
               
            
            Voices = await this.SpeechSynthesis.GetVoicesAsync();
        }

        private async Task PlaySlangAsync(string text, string lang) {
            var Voice = this.Voices.FirstOrDefault(v => v.Name.Contains("Helena"));

            var utterancet = new SpeechSynthesisUtterance
            {
                Text = text,
                Volume = 1.8,
                Pitch = 8.7,
                Rate = 0.40,
                Voice = Voice
            };
            Console.WriteLine(text);
            if (lang.Equals("en"))
            {
                utterancet.Lang = "en-US";
            }
            else {
                utterancet.Lang = "es-ES";
            }
            

            await this.SpeechSynthesis.SpeakAsync(utterancet);

        }

        private async Task SetSelectedPageAsync(int page)
        {
            var response = await this.SlangService.GetSlangs(page);
            ListSlangs = response.List;
            TotalSlangs = response.TotalSlangs;
        }


        public async Task GetListSlangs(int amountPage)
        {
            var response = await this.SlangService.GetSlangs(1);
            ListSlangs = response.List;
            TotalSlangs = response.TotalSlangs;
        }

        //public async Task DeleteAsync(int id)
        //{
        //    //Console.WriteLine("Se va a eliminar el id " + id);
        //    //var state = await this.SlangService.DeleteSlang(id);
        //    //Console.WriteLine("state" + state);
        //    //if (state == 1)
        //    //{
        //    //    Console.WriteLine("Se ha eliminado el id " + id);
        //    //    Navigator.NavigateTo("/slang");

        //    //    await GetListSlangs(1);
        //    //}
        //    //return;
        //}

    }
}
