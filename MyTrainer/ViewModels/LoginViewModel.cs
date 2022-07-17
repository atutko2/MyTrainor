using System;
using System.Windows.Input;
using Xamarin.Forms;
//using System.Security.Cryptography;
using MyTrainer.Views;
using Firebase.Auth;

namespace MyTrainer.ViewModels
{
    public class LoginViewModel
    {


        // To Do:
        // Add password reset link

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }

        public string Username { get; set; }
        public string Password { get; set; }
        private const string WebAPIKey = "AIzaSyA-md17IbC9MAZ50g5vUl5V1FsTUd6U0uw";

        //public const int SALT_SIZE = 32; // size in bytes
        //public const int HASH_SIZE = 64; // size in bytes
        //public const int ITERATIONS = 720000; // number of pbkdf2 iterations

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            SignUpCommand = new Command(SignUp);
        }

        private async void Login()
        {
            // get the salt from the database
            //byte[] salt = new byte[SALT_SIZE];
            //// temp value
            //salt = Encoding.GetEncoding("UTF-8").GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaa");

            // use the password provided and the salt to generate hash
            //Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(Password, salt, ITERATIONS);
            //var hash = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

            //Console.WriteLine(hash);
            // verify the hash is congruent with the database

            // Move the person to the main page and display user information

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {

                // To Do: Sanitize input
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Username, Password);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = Newtonsoft.Json.JsonConvert.SerializeObject(content);
                Xamarin.Essentials.Preferences.Set("MyFirebaseRefreshToken", serializedContent);

                // To Do: Make a call to get the user information and fill the Profile object
                // UID from firebase is here content.User.LocalId}
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch(Exception ex)
            {

                // To Do:
                // Display message when sign in information is wrong and display message when something unknown goes wrong
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

        }

        async private void SignUp()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
    }
}

