using TitleViewSearch.ViewModels;
using TitleViewSearch.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TitleViewSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesView : ContentPage
    {
        public MoviesView()
        {
            InitializeComponent();

            var viewModel = Locator.Instance.Resolve(typeof(MoviesViewModel)) as ViewModelBase;

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ViewModelBase)BindingContext).InitializeAsync();
        }
    }
}