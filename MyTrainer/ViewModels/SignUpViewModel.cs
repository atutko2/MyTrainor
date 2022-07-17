using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Security.Cryptography;
using System.Text;
using MyTrainer.Views;
using Firebase.Auth;

namespace MyTrainer.ViewModels
{
    public class SignUpViewModel
    {

        public ICommand CreateAccountCommand { get; }

        public const int SALT_SIZE = 32; // size in bytes
        public const int HASH_SIZE = 64; // size in bytes
        public const int ITERATIONS = 720000; // number of pbkdf2 iterations

        // the web key to firebase
        private const string WebAPIKey = "AIzaSyA-md17IbC9MAZ50g5vUl5V1FsTUd6U0uw";


        public SignUpViewModel()
        {
            CreateAccountCommand = new Command(CreateAccount);
        }

        public async void CreateAccount()
        {
            if (Password == ConfirmPassword)
            {
                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                    string gettoken = auth.FirebaseToken;
                    await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
                }
                catch (Exception ex)
                {
                    // pretty sure this only happens if there is no user (or maybe internet connection)?
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                }
            }
        }
        public String Email { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set; }
    }
}
