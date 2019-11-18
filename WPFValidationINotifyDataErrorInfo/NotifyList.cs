using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFValidationINotifyDataErrorInfo
{
    public class NotifyList<T> : ValidatableBindableBase
    {
        private List<T> _list;
        private string _propertyName;

        public T this[int index]
        {
            get => _list[index];
            set 
            {
                string indexedName = $"{_propertyName}[{index}]";
                Trace.WriteLine($"NotifyList<T>.SETTER={indexedName}; val={value}");
               _list[index] = value;                
                RaisePropertyChanged(indexedName);
                //Validate(value.ToString(), indexedName);
                Validate(value.ToString());
            }
        }
        public List<T> List => _list;
        public void Set(string propertyName, List<T> list)
        {
            _list = list;
            _propertyName = propertyName;
        }
    }
}
