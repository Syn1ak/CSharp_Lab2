using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CSharp_Lab2.Models
{
    class Person
    {
        private string name;
        private string surname;
        private string email;
        private DateTime birthdate;

        private readonly bool isAdult;
        private readonly bool isBirthday;
        private readonly string sunSign;
        private readonly string chineseSign;

        public Person(string name, string surname, string email, DateTime birthdate)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.birthdate = birthdate;
            isAdult = CheckAdult();
            isBirthday = CheckBirthday();
            sunSign = GetSunZodiacSign();
            chineseSign = GetChineseZodiacSign();
            int age = CalculateAge();
            if (age < 0)
            {
                throw new Exception("Too late birth date!");
            }
            if (age > 135)
            {
                throw new Exception("Too early birth date!");
            }
            Regex correctName = new Regex("^[A-Z](?:[a-z.,'_ -]*[a-zA-Z0-9])?$");
            if (!correctName.IsMatch(name))
            {
                throw new Exception("Invalid name!");
            }
            if (!correctName.IsMatch(surname))
            {
                throw new Exception("Invalid surname!");
            }
            Regex correctEmail = new Regex("^\\S+@\\S+\\.\\S+$");
            if (!correctEmail.IsMatch(email))
            {
                throw new Exception("Invalid email!");
            }
        }

        public Person(string firstName, string lastName, string email)
        : this(firstName, lastName, email, DateTime.MinValue) { }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, string.Empty, birthDate) { }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public DateTime Birthdate
        {
            get => birthdate;
            set => birthdate = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public bool IsAdult => isAdult;
        public bool IsBirthday => isBirthday;
        public string SunSign => sunSign;
        public string ChineseSign => chineseSign;


        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthdate.Year;
            if (Birthdate.Date > today.AddYears(-age))
                age--;
            return age;
        }

        private bool CheckAdult()
        {
            return CalculateAge() >= 18;
        }

        private bool CheckBirthday()
        {
            return Birthdate.Month == DateTime.Today.Month && Birthdate.Day == DateTime.Today.Day;
        }

        private string GetSunZodiacSign()
        {
            int month = Birthdate.Month;
            int day = Birthdate.Day;

            switch (month)
            {
                case 1:
                    return (day <= 20) ? "Capricorn" : "Aquarius";
                case 2:
                    return (day <= 19) ? "Aquarius" : "Pisces";
                case 3:
                    return (day <= 20) ? "Pisces" : "Aries";
                case 4:
                    return (day <= 20) ? "Aries" : "Taurus";
                case 5:
                    return (day <= 21) ? "Taurus" : "Gemini";
                case 6:
                    return (day <= 21) ? "Gemini" : "Cancer";
                case 7:
                    return (day <= 22) ? "Cancer" : "Leo";
                case 8:
                    return (day <= 23) ? "Leo" : "Virgo";
                case 9:
                    return (day <= 23) ? "Virgo" : "Libra";
                case 10:
                    return (day <= 23) ? "Libra" : "Scorpio";
                case 11:
                    return (day <= 22) ? "Scorpio" : "Sagittarius";
                case 12:
                    return (day <= 21) ? "Sagittarius" : "Capricorn";
                default:
                    return "None";
            }
        }

        private string GetChineseZodiacSign()
        {
            int year = Birthdate.Year;
            int chineseSign = year % 12;
            return ((ChineseZodiac)chineseSign).ToString();
        }

    }

    enum ChineseZodiac
    {
        Monkey,
        Rooster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Sheep
    }
}
