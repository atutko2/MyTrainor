using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using MyTrainer.Models;
using MyTrainer.StaticClasses;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyTrainer.ViewModels
{
    public class TodaysPageViewModel
    {
        public ICommand NewWorkoutPlan { get; }

        public TodaysPageViewModel()
        {
            NewWorkoutPlan = new Command(CreateWorkoutPlan);
        }

        private void CreateWorkoutPlan()
        {
            string filename = "MyTrainer.Resources.Levels.expert.json";
            var assembly = Assembly.GetExecutingAssembly();
            string jsonText;


            using (Stream stream = assembly.GetManifestResourceStream(filename))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                jsonText = result;
            }


            var tmp = JsonConvert.DeserializeObject<Dictionary<int, Exercise>>(jsonText);

            Console.WriteLine(tmp[0].Level);

        }
    }
}

