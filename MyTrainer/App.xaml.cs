using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MyTrainer.Models;
using MyTrainer.StaticClasses;
using MyTrainer.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTrainer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            FillAllExercises();

            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", ""))){
                Console.WriteLine(Preferences.Get("MyFirebaseRefreshToken", ""));

                // Deserialize the stored profile
                var content = Preferences.Get("MyProfile", "");
                Globals.MyProfile = JsonConvert.DeserializeObject<Profile>(content);

                MainPage = new NavigationPage(new MainPage());
            }
            else {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        private void FillAllExercises()
        {
            string filename = "MyTrainer.Resources.exercises.json";
            var assembly = Assembly.GetExecutingAssembly();
            string jsonText;

            using (Stream stream = assembly.GetManifestResourceStream(filename))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                jsonText = result;
            }

            Globals.AllExercises = JsonConvert.DeserializeObject<Exercises>(jsonText).exercises;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
