using Xamarin.Forms;

namespace MyTrainer.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.SignUpViewModel();
        }
    }
}

