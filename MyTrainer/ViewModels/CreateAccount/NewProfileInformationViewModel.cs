using System;
using System.Collections.Generic;
using System.Windows.Input;
using Firebase.Auth;
using MyTrainer.Models;
using MyTrainer.StaticClasses;
using MyTrainer.Views;
using MyTrainer.Views.CreateAccount;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyTrainer.ViewModels.CreateAccount
{
    public class NewProfileInformationViewModel
    {
        public ICommand CreateAccountCommand { get; }

        public NewProfileInformationViewModel()
        {
        }

        public NewProfileInformationViewModel(string Email, string Password)
        {
            CreateAccountCommand = new Command(CreateAccount);
            MyProfile = new Profile();
            MyProfile.Email = Email;
            tempPassword = Password;
        }

        public async void CreateAccount()
        {
            // Serialize the Profile and Store it for the next sign in
            // When a user actually logs in, this will be gathered through a query
            // But when the user is just opening the app it will be populated
            var serializedContent = Newtonsoft.Json.JsonConvert.SerializeObject(MyProfile);
            Xamarin.Essentials.Preferences.Set("MyProfile", serializedContent);

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(MyProfile.Email, tempPassword);
            string gettoken = auth.FirebaseToken;

            // TO DO:
            // Write the users profile to the DB after sanatizing input

            // Bring the user to the main page
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        public Profile MyProfile { get; set; }

        private string tempPassword { get; set; }

        // the web key to firebase
        private const string WebAPIKey = "AIzaSyA-md17IbC9MAZ50g5vUl5V1FsTUd6U0uw";
    }
}

