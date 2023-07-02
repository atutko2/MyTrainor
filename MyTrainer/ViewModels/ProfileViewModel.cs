using System;
using System.Windows.Input;
using Firebase.Auth;
using MyTrainer.StaticClasses;
using MyTrainer.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyTrainer.ViewModels
{
    public class ProfileViewModel
    {

        // To Do: Add Profile Model

        public ICommand LogoutCommand { get; }
        public ICommand ShowExercisesCommand { get; }
        public ICommand ShowProfileCommand { get; }

        private const string WebAPIKey = "AIzaSyA-md17IbC9MAZ50g5vUl5V1FsTUd6U0uw";
        private string email { get; set; }

        // Constructor
        public ProfileViewModel()
        {
            // Refreshs token and defines my commands
            GetProfileInformationAndRefreshToken();
            LogoutCommand = new Command(Logout);
            ShowExercisesCommand = new Command(GetAllExercises);
            ShowProfileCommand = new Command(PrintProfile);
        }

        // Display excercises page
        async private void GetAllExercises()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new ExercisesPage());

        }

        // Log the user out
        private void Logout()
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void PrintProfile()
        {
            Console.WriteLine(Globals.MyProfile.FirstName);
        }

        // Retrieves users information from the DB and refreshs the token
        private async void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            var savedFirebaseAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
            email = savedFirebaseAuth.User.Email;

            // try to refresh the token
            try
            {
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedFirebaseAuth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                // if it's expired, bring the user to the login page and clear the saved token
                if (RefreshedContent.IsExpired())
                {
                    Preferences.Remove("MyFirebaseRefreshToken");
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
            // if it fails the user could be without internet
            catch(Exception ex)
            {

                // To Do:
                // bring the user to the main page, but advise some functionality might be unavailable
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}

