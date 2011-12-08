using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string CurrentResultDisplay { get; private set; }

        private CalcEngine calculatorEngine;
        private DisplayResult displayResult;

        public MainWindow()
        {
            InitializeComponent();

            displayResult = new DisplayResult() { ResultText = "0" };
            this.DataContext = displayResult;

            calculatorEngine = new CalcEngine();
        }

        private void buttonBackspace_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.RemoveDigitFromCurrentValueText();
            UpdateDisplay(calculatorEngine.CurrentDisplayText);
        }

        private void UpdateDisplay(string updatedText)
        {
             displayResult.ResultText = updatedText;
        }

        private void buttonCE_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.ClearCurrentValue();
            UpdateDisplay(calculatorEngine.CurrentDisplayText);
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.ClearCurrentValue();
            calculatorEngine.ClearTotalValue();
            UpdateDisplay(calculatorEngine.CurrentDisplayText);
        }

        private void buttonDigit_Click(object sender, RoutedEventArgs e)
        {
            Button digitButton = sender as Button;

            if (digitButton != null)
            {
                calculatorEngine.AddDigitToCurrentValueText(digitButton.Content.ToString());
                UpdateDisplay(calculatorEngine.CurrentDisplayText);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Add));
 
            UpdateDisplay(calculatorEngine.TotalValueText);
            calculatorEngine.ClearCurrentValue();
        }

        private void buttonSubtract_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Subtract));

            UpdateDisplay(calculatorEngine.TotalValueText);
            calculatorEngine.ClearCurrentValue();
        }

        private void buttonMultiple_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Multiple));

            UpdateDisplay(calculatorEngine.TotalValueText);
            calculatorEngine.ClearCurrentValue();
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Divide));

            UpdateDisplay(calculatorEngine.TotalValueText);
            calculatorEngine.ClearCurrentValue();
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            UpdateDisplay(calculatorEngine.TotalValueText);
            calculatorEngine.ClearCurrentValue();
        }

        private void buttonSqrt_Click(object sender, RoutedEventArgs e)
        {
            calculatorEngine.UpdateCurrentValue(new CalcEngine.UpdateCurrentValueHandler(AdvancedMath.SquareRoot));

            UpdateDisplay(calculatorEngine.CurrentDisplayText);
            
        }

        private void buttonPercent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonInvert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonChangeSign_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonMemoryClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonMemoryRead_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonMemorySet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonMemoryAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
