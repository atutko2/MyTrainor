using System;
using System.Collections.Generic;
using MyTrainer.ViewModels;
using Xamarin.Forms;

namespace MyTrainer.Views
{
    public partial class WorkoutInfoCollectorPage : ContentPage
    {
        public WorkoutInfoCollectorPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutInfoCollectorViewModel();
        }

        void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
        }
    }
}

