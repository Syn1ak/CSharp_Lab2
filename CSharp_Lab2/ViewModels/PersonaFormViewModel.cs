using CSharp_Lab2.Models;
using CSharp_Lab2.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using CSharp_Lab2.Exceptions;
using CSharp_Lab2.Services;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Lab2.ViewModels
{
    public class PersonaFormViewModel : INotifyPropertyChanged
    {
        private readonly UserService userService;
        private readonly DateTime defaultDate = new DateTime(2000, 1, 1);
        private ObservableCollection<Person> personsList;
        private ObservableCollection<Person> filteredPersonsList;

        private string name;
        private string surname;
        private string email;
        private DateTime birthDate;
        private bool isAdult;
        private bool isBirthday;
        private string sunSign;
        private string chineseSign;


        private bool isEnabled = true;
        private bool isUpdate = false;
        private string updateEmail;

        private string filterName = "";
        private string filterSurname = "";
        private string filterEmail = "";
        private DateTime filterBirthDateFrom = new DateTime(1980, 1, 1);
        private DateTime filterBirthDateTo = new DateTime(2005, 1, 1);
        private string filterIsAdult = "Both";
        private string filterIsBirthday = "Both";
        private string filterSunSign = "All";
        private string filterChineseSign = "All";

        private ICommand proceedCommand;
        private ICommand cancelCommand;
        private ICommand deleteCommand;
        private ICommand updateCommand;
        private ICommand filterCommand;

        public PersonaFormViewModel()
        {
            userService = new UserService();
            birthDate = defaultDate;
            LoadData();
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => SetProperty(ref birthDate, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public bool IsAdult
        {
            get => isAdult;
            set => SetProperty(ref isAdult, value);
        }

        public bool IsBirthday
        {
            get => isBirthday;
            set => SetProperty(ref isBirthday, value);
        }

        public string SunSign
        {
            get => sunSign;
            set => SetProperty(ref sunSign, value);
        }

        public string ChineseSign
        {
            get => chineseSign;
            set => SetProperty(ref chineseSign, value);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        public ObservableCollection<Person> PersonsList
        {
            get => filteredPersonsList;
            private set => SetProperty(ref filteredPersonsList, value);
        }

        public string FilterName
        {
            get => filterName;
            set => SetProperty(ref filterName, value);
        }

        public string FilterSurname
        {
            get => filterSurname;
            set => SetProperty(ref filterSurname, value);
        }

        public DateTime FilterBirthDateFrom
        {
            get => filterBirthDateFrom;
            set => SetProperty(ref filterBirthDateFrom, value);
        }

        public DateTime FilterBirthDateTo
        {
            get => filterBirthDateTo;
            set => SetProperty(ref filterBirthDateTo, value);
        }

        public string FilterEmail
        {
            get => filterEmail;
            set => SetProperty(ref filterEmail, value);
        }

        public string FilterIsAdult
        {
            get => filterIsAdult;
            set => SetProperty(ref filterIsAdult, value);
        }

        public string FilterIsBirthday
        {
            get => filterIsBirthday;
            set => SetProperty(ref filterIsBirthday, value);
        }

        public string FilterSunSign
        {
            get => filterSunSign;
            set => SetProperty(ref filterSunSign, value);
        }

        public string FilterChineseSign
        {
            get => filterChineseSign;
            set => SetProperty(ref filterChineseSign, value);
        }

        public ICommand ProceedCommand =>
            proceedCommand ??= new RelayCommand<object>(_ => ProceedAsync(), CanProceed);

        public ICommand CancelCommand =>
            cancelCommand ??= new RelayCommand<object>(_ => Cancel(), _ => isUpdate);

        public ICommand DeleteCommand =>
            deleteCommand ??= new RelayCommand<Person>(person => DeleteAsync(person), _ => !isUpdate);

        public ICommand UpdateCommand =>
            updateCommand ??= new RelayCommand<Person>(person => Update(person), _ => !isUpdate);

        public ICommand FilterCommand =>
            filterCommand ??= new RelayCommand<object>(_ => ApplyFilters(), _ => !isUpdate);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void LoadData()
        {
            personsList = new ObservableCollection<Person>(userService.GetAllUsers());
            ApplyFilters();
        }

        private bool CanProceed(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !BirthDate.Equals(DateTime.MinValue);
        }

        private async void ProceedAsync()
        {
            IsEnabled = false;
            try
            {
                var person = new Person(Name, Surname, Email, BirthDate);

                if (isUpdate)
                {
                    await userService.UpdatePerson(person, updateEmail);
                }
                else
                {
                    await userService.AddPerson(person);
                }

                ResetForm();
                LoadData();
            }
            catch (PersonValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void ResetForm()
        {
            isUpdate = false;
            updateEmail = null;

            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            BirthDate = defaultDate;
        }

        private void Cancel()
        {
            ResetForm();
        }

        private async void DeleteAsync(Person person)
        {
            IsEnabled = false;
            try
            {
                userService.DeletePerson(person.Email);
                personsList.Remove(person);
                ApplyFilters();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void Update(Person person)
        {
            isUpdate = true;
            updateEmail = person.Email;

            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            BirthDate = person.Birthdate;
        }

        private void ApplyFilters()
        {
            var filtered = personsList.AsEnumerable();

            if (!string.IsNullOrEmpty(FilterName))
                filtered = filtered.Where(user => user.Name.ToLower().Contains(FilterName.ToLower()));

            if (!string.IsNullOrEmpty(FilterSurname))
                filtered = filtered.Where(user => user.Surname.ToLower().Contains(FilterSurname.ToLower()));

            if (!string.IsNullOrEmpty(FilterEmail))
                filtered = filtered.Where(user => user.Email.ToLower().Contains(FilterEmail.ToLower()));

            filtered = filtered.Where(user => user.Birthdate >= FilterBirthDateFrom &&
                                              user.Birthdate <= FilterBirthDateTo);

            switch (FilterIsBirthday)
            {
                case "Is Birthday":
                    filtered = filtered.Where(user => user.IsBirthday);
                    break;
                case "Isn't Birthday":
                    filtered = filtered.Where(user => !user.IsBirthday);
                    break;
            }

            switch (FilterIsAdult)
            {
                case "Is Adult":
                    filtered = filtered.Where(user => user.IsAdult);
                    break;
                case "Isn't Adult":
                    filtered = filtered.Where(user => !user.IsAdult);
                    break;
            }

            if (FilterSunSign != "All")
                filtered = filtered.Where(user => user.SunSign == FilterSunSign);

            if (FilterChineseSign != "All")
                filtered = filtered.Where(user => user.ChineseSign == FilterChineseSign);

            PersonsList = new ObservableCollection<Person>(filtered);
        }
    }
}