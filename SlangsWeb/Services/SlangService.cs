
using Newtonsoft.Json;
using SlangModels.Dtos;
//using SlangsWeb.Models;
using SlangsWeb.Services.Contracts;
using System.Net.Http.Json;
using System.Text;

namespace SlangsWeb.Services
{
    public class SlangService : ISlangService
    {
        private readonly HttpClient httpClient;

        public SlangService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseDto> GetSlangs(int page)
        {
            try
            {
                //var slangs = await this.httpClient.GetFromJsonAsync<IEnumerable<SlangDto>>($"api/Slang?page={page}&quantity={5}");

                var slangs = await this.httpClient.GetFromJsonAsync<ResponseDto>($"api/Slang?page={page}&quantity={5}");
                
                return slangs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SlangDto> GetSlangById(int id)
        {
            try
            {
                      var slang = await this.httpClient.GetFromJsonAsync<SlangDto>($"api/Slang/{id}");

                return slang;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddSlang(NewSlangDto newSlangDto)
        {
            try
            {
                  var response = await httpClient.PostAsJsonAsync<NewSlangDto>("api/Slang",newSlangDto);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("success");
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public async Task<int> UpdateSlang(SlangDto SlangDto)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync<SlangDto>("api/Slang", SlangDto);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("success");
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public async Task<int> DeleteSlang(int id)
        {
            try
            {
                var response = await this.httpClient.DeleteAsync($"api/Slang/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("success ");
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
