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

        private CalcEngine engine;
        private DisplayResult displayResult;

        public MainWindow()
        {
            InitializeComponent();

            displayResult = new DisplayResult() { ResultText = "0" };
            this.DataContext = displayResult;

            engine = new CalcEngine();
        }

        private void buttonBackspace_Click(object sender, RoutedEventArgs e)
        {
            engine.RemoveDigitFromCurrentValueText();
            UpdateDisplay(engine.CurrentDisplayText);
        }

        private void UpdateDisplay(string updatedText)
        {
             displayResult.ResultText = updatedText;
        }

        private void buttonCE_Click(object sender, RoutedEventArgs e)
        {
            engine.ClearCurrentValue();
            UpdateDisplay(engine.CurrentDisplayText);
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            engine.ClearCurrentValue();
            engine.ClearTotalValue();
            UpdateDisplay(engine.CurrentDisplayText);
        }

        private void buttonDigit_Click(object sender, RoutedEventArgs e)
        {
            Button digitButton = sender as Button;

            if (digitButton != null)
            {
                engine.AddDigitToCurrentValueText(digitButton.Content.ToString());
                UpdateDisplay(engine.CurrentDisplayText);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            engine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Add));
 
            UpdateDisplay(engine.TotalValueText);
            engine.ClearCurrentValue();
        }

        private void buttonSubtract_Click(object sender, RoutedEventArgs e)
        {
            engine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Subtract));

            UpdateDisplay(engine.TotalValueText);
            engine.ClearCurrentValue();
        }

        private void buttonMultiple_Click(object sender, RoutedEventArgs e)
        {
            engine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Multiple));

            UpdateDisplay(engine.TotalValueText);
            engine.ClearCurrentValue();
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            engine.UpdateTotalValue(new CalcEngine.UpdateTotalHandler(SimpleMath.Divide));

            UpdateDisplay(engine.TotalValueText);
            engine.ClearCurrentValue();
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            UpdateDisplay(engine.TotalValueText);
            engine.ClearCurrentValue();
        }

        private void buttonSqrt_Click(object sender, RoutedEventArgs e)
        {
            engine.UpdateCurrentValue(new CalcEngine.UpdateCurrentValueHandler(AdvancedMath.SquareRoot));

            UpdateDisplay(engine.CurrentDisplayText);
            
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
