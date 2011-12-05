using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class CalcEngine
    {
        private StringBuilder valueTextBuilder;
        public string CurrentDisplayText 
        {
            get
            {
                if (valueTextBuilder.Length > 0)
                    return valueTextBuilder.ToString();
                else
                    return "0";
            }
        }
        public string TotalValueText
        {
            get { return totalValue.ToString(); }
        }
         
        private double currentValue;        
        private double totalValue; 

        public delegate double UpdateCurrentValueHandler(double currentValue);
        public delegate double UpdateTotalHandler(double currentValue, double totalValue);

        public CalcEngine()
        {
            valueTextBuilder = new StringBuilder("");
        }

        public void AddDigitToCurrentValueText(string digit)
        {
            valueTextBuilder.Append(digit);
        }

        public void RemoveDigitFromCurrentValueText()
        {
            valueTextBuilder.Length = valueTextBuilder.Length - 1;
        }

        public void ClearCurrentValue()
        {
            currentValue = 0.0;
            valueTextBuilder.Clear();            
        }

        public void ClearTotalValue()
        {
            totalValue = 0.0;
        }

        public void UpdateCurrentValue(UpdateCurrentValueHandler updateCurrentHandler)
        {          
            currentValue = updateCurrentHandler(Double.Parse(CurrentDisplayText));
            
            valueTextBuilder.Clear();
            valueTextBuilder.Append(currentValue.ToString());
        }

        public void UpdateTotalValue(UpdateTotalHandler updateHandler)
        {
            currentValue = Double.Parse(CurrentDisplayText);

            totalValue = updateHandler(currentValue, totalValue);
        }
    }
}
