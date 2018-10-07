using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TitleViewSearch.Models;
using TitleViewSearch.Services.Movies;
using TitleViewSearch.ViewModels.Base;
using Xamarin.Forms;

namespace TitleViewSearch.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        private ObservableCollection<Movie> _movies;

        private IMoviesService _moviesService;

        public MoviesViewModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand => new Command(async (query) => await LoadMoviesAsync(query?.ToString()));

        public override async Task InitializeAsync(object navigationData = null)
        {
            await LoadMoviesAsync(string.Empty);
        }

        async Task LoadMoviesAsync(string query)
        {
            IsBusy = true;

            SearchResponse<Movie> movies = null;

            if (string.IsNullOrEmpty(query))
            {
                movies = await _moviesService.GetPopularAsync();
            }
            else
            {
                movies = await _moviesService.SearchAsync(query);
            }

            Movies = new ObservableCollection<Movie>(movies?.Results);

            IsBusy = false;
        }
    }
}