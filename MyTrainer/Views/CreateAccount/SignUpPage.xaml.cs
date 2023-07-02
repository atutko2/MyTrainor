using Xamarin.Forms;

namespace MyTrainer.Views.CreateAccount
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CreateAccount.SignUpViewModel();
        }
    }
}

