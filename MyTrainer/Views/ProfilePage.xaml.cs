using Xamarin.Forms;

namespace MyTrainer.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ProfileViewModel();
        }
    }
}

