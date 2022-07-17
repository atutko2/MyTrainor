using Xamarin.Forms;

namespace MyTrainer.Views
{
    public partial class TodayPage : ContentPage
    {
        public TodayPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.TodaysPageViewModel();
        }
    }
}

