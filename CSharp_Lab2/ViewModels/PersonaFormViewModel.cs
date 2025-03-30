using CSharp_Lab2.Models;
using CSharp_Lab2.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CSharp_Lab2.ViewModels
{
    public class PersonaFormViewModel : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private string email;
        private DateTime? birthDate = null;
        private Person person;

        private bool isEnabled = true;

        private RelayCommand<object> _proceedCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        public PersonaFormViewModel()
        {
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public string Name
        {
            get => name;
            set { name = value; }
        }

        public string Surname
        {
            get => surname;
            set { surname = value; }
        }

        public string Email
        {
            get => email;
            set { email = value; }
        }

        public DateTime? BirthDate
        {
            get => birthDate;
            set { birthDate = value; }
        }

        public string PersonName => person?.Name;
        public string PersonSurname => person?.Surname;
        public string PersonEmail => person?.Email;
        public string PersonBirthdate => person?.Birthdate.ToString("yyyy-MM-dd") ?? string.Empty;
        public string PersonSunSign => person?.SunSign;
        public string PersonChineseSign => person?.ChineseSign;
        public string PersonIsAdult => person?.IsAdult.ToString();
        public string PersonIsBirthday => person?.IsBirthday.ToString();

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanProceed);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool CanProceed(object parameter)
        {
            return !(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname)
                || string.IsNullOrWhiteSpace(email) || birthDate == null);
        }

        private async void Proceed()
        {
            try
            {
                IsEnabled = false;
                await Task.Delay(1000);
                person = new Person(name, surname, email, birthDate ?? DateTime.MinValue);
                OnPropertyChanged(nameof(PersonName));
                OnPropertyChanged(nameof(PersonSurname));
                OnPropertyChanged(nameof(PersonEmail));
                OnPropertyChanged(nameof(PersonSunSign));
                OnPropertyChanged(nameof(PersonChineseSign));
                OnPropertyChanged(nameof(PersonBirthdate));
                OnPropertyChanged(nameof(PersonIsAdult));
                OnPropertyChanged(nameof(PersonIsBirthday));
                IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                IsEnabled = true;
                return;
            }
        }
    }
}
