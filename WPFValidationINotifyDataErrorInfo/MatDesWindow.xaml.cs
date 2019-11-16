using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFValidationINotifyDataErrorInfo
{
    /// <summary>
    /// Interaction logic for MatDesWindow.xaml
    /// </summary>
    public partial class MatDesWindow : Window
    {
        private MainViewModel model;
        public MatDesWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
            model = mainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var txtbox = new TextBox();
            txtbox.Margin = new Thickness(20);
            HintAssist.SetHint(txtbox, "payrec");
            //var binding = new Binding($"{nameof(model.PayrecToSend)}.{nameof(model.PayrecToSend.Name)}");
            var binding = new Binding($"PayName");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnNotifyDataErrors = true;
            txtbox.SetBinding(TextBox.TextProperty, binding);
            mPanel.Children.Add(txtbox);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var txtbox = new TextBox();
            txtbox.Margin = new Thickness(20);
            HintAssist.SetHint(txtbox, "string username");
            var binding = new Binding($"UserName");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //binding.ValidatesOnNotifyDataErrors = true;
            txtbox.SetBinding(TextBox.TextProperty, binding);
            mPanel.Children.Add(txtbox);
        }
    }
}
