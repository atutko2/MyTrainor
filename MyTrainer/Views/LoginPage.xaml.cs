﻿using Xamarin.Forms;

namespace MyTrainer.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.LoginViewModel();
        }

    }
}

