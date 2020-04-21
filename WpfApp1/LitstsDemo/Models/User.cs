using System.ComponentModel;

namespace ListsDemo.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;
        private string nameError;
        private string passwordError;

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }
        public string PasswordError
        {
            get
            {
                return passwordError;
            }
            set
            {
                if (passwordError != value)
                {
                    passwordError = value;
                    OnPropertyChanged("PasswordError");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return NameError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }
                            break;
                        }
                    case "Password":
                        {
                            PasswordError = "";

                            if (string.IsNullOrEmpty(Password))
                            {
                                PasswordError = "Password cannot be empty.";
                            }
                            if (Password.Length > 30)
                            {
                                PasswordError = "Password cannot be longer than 30 characters.";
                            }
                            break;
                        }
                }
                return null;
            }
        }
        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}