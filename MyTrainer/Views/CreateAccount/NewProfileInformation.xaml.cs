using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyTrainer.Views.CreateAccount
{
    public partial class NewProfileInformation : ContentPage
    {
        private string email;
        private string password;

        public NewProfileInformation()
        {
            InitializeComponent();
        }

        public NewProfileInformation(string email, string password)
        {
            InitializeComponent();
            BindingContext = new ViewModels.CreateAccount.NewProfileInformationViewModel(email, password);
        }
    }
}

