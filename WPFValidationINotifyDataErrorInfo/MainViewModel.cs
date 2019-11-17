using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace WPFValidationINotifyDataErrorInfo
{
    public class MainViewModel : BindableBase, INotifyDataErrorInfo
    {
        private string _userName;
        private PayRecord _payrecToSend = new PayRecord();        
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public MainViewModel()
        {
            UserName = null;
            _payrecToSend.AttrStrings = new List<string>() { "one", "two", "three"};
        }

        public string PayName
        {
            get => PayrecToSend?.Name;
            set
            {
                Trace.WriteLine($"PayName SETTER: nam={PayrecToSend.Name}=>{value};");
                PayrecToSend.Name = value;
                RaisePropertyChanged(nameof(PayName));
                ValidatePayrec();
            }
        }

        public List<string> AttrStrings
        {
            get
            {
                Trace.WriteLine($"AttrStrings GET");
                return PayrecToSend.AttrStrings;                
            }
            set
            {
                Trace.WriteLine($"AttrStrings SETTER");
                PayrecToSend.AttrStrings = value;
                RaisePropertyChanged(nameof(AttrStrings));
            }
        }

        public PayRecord PayrecToSend 
        {
            get => _payrecToSend;
            set
            {
                Trace.WriteLine($"Payrec SETTER: nam={_payrecToSend.Name}=>{value.Name}; sum={_payrecToSend.Summa}=>{value.Summa};");
                SetProperty(ref _payrecToSend, value);                
                //ValidatePayrec();
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
                Trace.WriteLine($"UserName SETTER: nam={value};");
                ValidateUserName();                
            }
        }

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged=(s,e)=> { };

        public IEnumerable GetErrors(string propertyName)
        {
            Trace.WriteLine($"GetErrors() propName={propertyName}");
            return _errorsByPropertyName.ContainsKey(propertyName) ?
                _errorsByPropertyName[propertyName] : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            Trace.WriteLine($"OnErrorsChanged() propName={propertyName}");
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateUserName()
        {
            ClearErrors(nameof(UserName));

            if (string.IsNullOrWhiteSpace(UserName))
                AddError(nameof(UserName), "Username cannot be empty.");

            if (string.Equals(UserName, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(nameof(UserName), "Admin is not valid username.");

            if (UserName == null || UserName?.Length <= 5)
                AddError(nameof(UserName), "Username must be at least 6 characters long.");
        }

        private void ValidatePayrec()
        {
            Trace.WriteLine($"ValidatePayrec():");
            ClearErrors(nameof(PayName));

            if (string.IsNullOrWhiteSpace(PayName))
                AddError(nameof(PayName), "Username cannot be empty.");

            if (string.Equals(PayName, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(nameof(PayName), "Admin is not valid username.");

            if (PayName == null || PayName?.Length <= 5)
                AddError(nameof(PayName), "Username must be at least 6 characters long.");
        }

        private void AddError(string propertyName, string error)
        {
            Trace.WriteLine($"AddError() propName={propertyName} error={error}");
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            Trace.WriteLine($"ClearErrors() propName={propertyName}");
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
