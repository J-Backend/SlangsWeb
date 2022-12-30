using Microsoft.AspNetCore.Components;

namespace SlangsWeb.Pages.Components
{
    public partial class Pagination : ComponentBase
    {
        private int CurrentPage { get; set; } = 1;


        [Parameter]
        public int TotalSlangs { get; set; }

        public int CountPages { get; set; }

        [Parameter]
        public EventCallback<int> SetSelectedPage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GetCountPages();
            await ShowPages();
        }
        private void GetCountPages()
        {
            Console.WriteLine("TotalSlangs: " + TotalSlangs);
            var total = Convert.ToDouble(TotalSlangs);

            var amount = total / 5;

            CountPages = (int)Math.Ceiling(amount);
            Console.WriteLine("TotalPages: " + CountPages);
        }
        protected async Task NextPage()
        {
            if (CurrentPage < CountPages)
            {
                CurrentPage++;
                await ShowPages();
                Console.WriteLine("Next page clicked " + CurrentPage);
            }
        }

        protected async Task PrevPage()
        {
            if (CurrentPage>1)
            {
                CurrentPage--;
                await ShowPages();
                Console.WriteLine("Prev page clicked " + CurrentPage);
            }
           

        }

        protected async Task SelectedPage(int page) {

            CurrentPage = page;
            await ShowPages();
        }

        protected async Task ShowPages()
        {
            await SetSelectedPage.InvokeAsync(CurrentPage);
        }
        //[Parameter]
        //public int CurrentPage { get; set; } = 1;
        //[Parameter]
        //public int TotalPages { get; set; }
        //[Parameter]
        //public int Range { get; set; } = 3;
        //[Parameter]
        //public EventCallback<int> SetSelectedPage { get; set; }

        //protected override void OnParametersSet() {

        //    LoadPages();
        //}

        //private void LoadPages() { 

        //}
    }
}
