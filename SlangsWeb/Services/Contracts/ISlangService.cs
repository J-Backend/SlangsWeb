using SlangModels.Dtos;


namespace SlangsWeb.Services.Contracts
{
    public interface ISlangService
    {
        public Task<ResponseDto> GetSlangs(int page);

        public Task<SlangDto> GetSlangById(int id);

        public Task<int> AddSlang(NewSlangDto newSlangDto);

        public Task<int> UpdateSlang(SlangDto SlangDto);

        public Task<int> DeleteSlang(int id);
    }
}
