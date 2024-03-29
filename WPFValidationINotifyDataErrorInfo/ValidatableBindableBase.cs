﻿using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFValidationINotifyDataErrorInfo
{
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        public void Validate(string propertyValue, [CallerMemberName] string propertyName = null)
        {
            Trace.WriteLine($"ValidatableBindableBase.Validate({propertyValue}, {propertyName})");
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(propertyValue))
                AddError(propertyName, "Username cannot be empty.");

            if (string.Equals(propertyValue, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(propertyName, "Admin is not valid username.");

            if (propertyValue == null || propertyValue?.Length <= 5)
                AddError(propertyName, "Username must be at least 6 characters long.");
        }
        #region iNotifyDataErrors
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();
        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = (s, e) => { };

        public IEnumerable GetErrors(string propertyName)
        {
            Trace.WriteLine($"{nameof(ValidatableBindableBase)}.GetErrors({propertyName})");
            return _errorsByPropertyName.ContainsKey(propertyName) ?
                _errorsByPropertyName[propertyName] : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            Trace.WriteLine($"OnErrorsChanged({propertyName})");
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string propertyName, string error)
        {
            Trace.WriteLine($"{nameof(ValidatableBindableBase)}.AddError({propertyName}) error={error}");
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
            Trace.WriteLine($"{nameof(ValidatableBindableBase)}.ClearErrors({propertyName})");
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
        #endregion
    }
}
