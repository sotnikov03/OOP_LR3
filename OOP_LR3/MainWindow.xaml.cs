using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_LR3
{
    public partial class MainWindow : Window
    {
        private IOperation _selectedOperation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            button.Content = "True";
            button.Background = new SolidColorBrush(Color.FromRgb(74, 144, 226)); 
            button.Foreground = new SolidColorBrush(Colors.White);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            button.Content = "False";
            button.Background = new SolidColorBrush(Color.FromRgb(224, 224, 224)); 
            button.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void OperationSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string operation = (OperationSelector.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();
            _selectedOperation = operation switch
            {
                "AND" => new AndOperation(),
                "OR" => new OrOperation(),
                "XOR" => new XorOperation(),
                "Штрих Шеффера" => new NandOperation(),
                _ => null
            };
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOperation == null)
            {
                MessageBox.Show("Пожалуйста, выберите операцию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool input1 = Input1.IsChecked == true;
            bool input2 = Input2.IsChecked == true;
            bool result = _selectedOperation.Execute(input1, input2);

            ResultText.Text = $"Результат: {result}";
        }
    }
}
