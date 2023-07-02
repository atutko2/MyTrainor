using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Security.Cryptography;
using System.Text;
using MyTrainer.Views;
using Firebase.Auth;
using MyTrainer.Views.CreateAccount;

namespace MyTrainer.ViewModels.CreateAccount
{
    public class SignUpViewModel : INotifyPropertyChanged
    {

        public ICommand CreateAccountCommand { get; }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public SignUpViewModel()
        {
            CreateAccountCommand = new Command(CreateAccount);
            BadEmail = false;
            BadPassword = false;
            UnknownError = false;
            PasswordLength = false;
        }

        public async void CreateAccount()
        {
            if (Password == ConfirmPassword && IsValidEmail(Email) && Password.Length >= 5)
            {
                //Application.Current.MainPage = new NavigationPage(new NewProfileInformation(Email, Password));
                await Application.Current.MainPage.Navigation.PushAsync(new NewProfileInformation(Email, Password));
            }
            else
            {
                if (!IsValidEmail(Email))
                {
                    BadEmail = true;
                }
                if (Password != ConfirmPassword)
                {
                    BadPassword = true;
                }
                else if (Password.Length < 6)
                {
                    PasswordLength = true;
                }
            }
        }
        public String Email { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set; }

        private bool badEmail { get; set; }

        public bool BadEmail {
            get => badEmail;
            set
            {
                badEmail = value;
                OnPropertyChanged("BadEmail");
            }
        }

        private bool badPassword { get; set; }

        public bool BadPassword
        {
            get => badPassword;
            set
            {
                badPassword = value;
                OnPropertyChanged("BadPassword");
            }
        }

        private bool passwordLength { get; set; }

        public bool PasswordLength
        {
            get => passwordLength;
            set
            {
                passwordLength = value;
                OnPropertyChanged("PasswordLength");
            }
        }

        private bool unknownError { get; set; }

        public bool UnknownError
        {
            get => unknownError;
            set
            {
                unknownError = value;
                OnPropertyChanged("UnknownError");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handle = PropertyChanged;
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
