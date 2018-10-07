using System.Threading.Tasks;
using TitleViewSearch.Models;
using TitleViewSearch.Services.Request;

namespace TitleViewSearch.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly IRequestService _requestProvider;

        public MoviesService(IRequestService requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<SearchResponse<Movie>> SearchAsync(string query, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}search/movie?api_key={AppSettings.ApiKey}&language={language}&query={query}";

            SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

            return response;
        }

        public async Task<SearchResponse<Movie>> GetPopularAsync(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/popular?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

            return response;
        }
    }
}