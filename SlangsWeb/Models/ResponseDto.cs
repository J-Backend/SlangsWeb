using SlangModels.Dtos;

namespace SlangsWeb.Models
{
    public class ResponseDto
    {
        public int TotalSlangs { get; set; }
        public IEnumerable<SlangDto> List { get; set; }
    }
}
