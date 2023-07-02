using System;
using System.Windows.Input;
using MyTrainer.Views;
using Xamarin.Forms;

namespace MyTrainer.ViewModels
{
    public class WorkoutCreatorViewModel
    {
        public ICommand GenerateWorkoutPlan { get; }
        public ICommand CreateOwnWorkoutPlan { get; }

        public WorkoutCreatorViewModel()
        {
            GenerateWorkoutPlan = new Command(GenerateRandomWorkoutPlan);
            CreateOwnWorkoutPlan = new Command(CreateOwnPlan);
        }

        private void CreateOwnPlan()
        {
            throw new NotImplementedException();
        }

        async private void GenerateRandomWorkoutPlan()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new WorkoutInfoCollectorPage());
        }

    }
}

