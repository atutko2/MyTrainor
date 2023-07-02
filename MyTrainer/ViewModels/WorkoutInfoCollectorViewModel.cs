using System;
using System.Collections.ObjectModel;
using MyTrainer.Models;

namespace MyTrainer.ViewModels
{
    public class WorkoutInfoCollectorViewModel
    {
        ObservableCollection<Day> daysOfTheWeek = new ObservableCollection<Day>();
        public ObservableCollection<Day> DaysOfTheWeek {  get { return daysOfTheWeek;  } }

        public WorkoutInfoCollectorViewModel()
        {

        }
    }
}

