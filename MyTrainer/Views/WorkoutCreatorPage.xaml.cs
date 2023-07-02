using System;
using System.Collections.Generic;
using MyTrainer.ViewModels;
using Xamarin.Forms;

namespace MyTrainer.Views
{
    public partial class WorkoutCreatorPage : ContentPage
    {
        public WorkoutCreatorPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutCreatorViewModel();
        }
    }
}

