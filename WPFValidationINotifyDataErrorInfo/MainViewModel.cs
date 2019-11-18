using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace WPFValidationINotifyDataErrorInfo
{
    public class MainViewModel : ValidatableBindableBase
    {
        private string _userName;
        private PayRecord _payrecToSend = new PayRecord();
        private ObservableCollection<string> _observAttr = new ObservableCollection<string>() { "obs1", "obs2", "obs3" };
        private NotifyList<string> _notifyAttr = new NotifyList<string>();

        public MainViewModel()
        {
            UserName = null;
            _payrecToSend.AttrStrings = new List<string>() { "one", "two", "three"};
            _notifyAttr.Set(nameof(NotifyAttr), new List<string>() { "notif1","notif2","notif3" });
        }
        public string this[int index]
        {
            get => AttrStrings[index];
            set
            {
                AttrStrings[index] = value;
                Validate(value, $"[{index}]");
                RaisePropertyChanged($"[{index}]");
            }
        }
        public string PayName
        {
            get => PayrecToSend?.Name;
            set
            {
                Trace.WriteLine($"PayName SETTER: nam={PayrecToSend.Name}=>{value};");
                PayrecToSend.Name = value;
                Validate(PayName);
                RaisePropertyChanged();
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
        public ObservableCollection<string> ObservAttr
        {
            get { Trace.WriteLine($"ObservAttr GET:"); return _observAttr; }
            set
            {
                Trace.WriteLine($"ObservAttr SETTER:");
                _observAttr = value;
                RaisePropertyChanged(nameof(ObservAttr));
            }
        }
        public NotifyList<string> NotifyAttr
        {
            get { Trace.WriteLine($"NotifyAttr GET:"); return _notifyAttr; }
            //set
            //{
            //    Trace.WriteLine($"NotifyAttr SETTER:");
            //    _notifyAttr = value;
            //    RaisePropertyChanged(nameof(_notifyAttr));
            //    ValidateObservAttr();
            //}
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
                Validate(UserName);
            }
        }
    }
}
