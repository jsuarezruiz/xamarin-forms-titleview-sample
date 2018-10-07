using System.Threading.Tasks;
using TitleViewSearch.Models;

namespace TitleViewSearch.Services.Movies
{
    public interface IMoviesService
    {
        Task<SearchResponse<Movie>> SearchAsync(string query, string language = "en");

        Task<SearchResponse<Movie>> GetPopularAsync(int pageNumber = 1, string language = "en");
    }
}