using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class CalcEngine
    {
        private StringBuilder valueStringBuilder;
        public string CurrentDisplayText 
        {
            get
            {
                if (valueStringBuilder.Length > 0)
                    return valueStringBuilder.ToString();
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
            valueStringBuilder = new StringBuilder("");
        }

        public void AddDigitToCurrentValueText(string digit)
        {
            valueStringBuilder.Append(digit);
        }

        public void RemoveDigitFromCurrentValueText()
        {
            valueStringBuilder.Length = valueStringBuilder.Length - 1;
        }

        public void ClearCurrentValue()
        {
            currentValue = 0.0;
            valueStringBuilder.Clear();            
        }

        public void ClearTotalValue()
        {
            totalValue = 0.0;
        }

        public void UpdateCurrentValue(UpdateCurrentValueHandler updateCurrentHandler)
        {          
            currentValue = updateCurrentHandler(Double.Parse(CurrentDisplayText));
            
            valueStringBuilder.Clear();
            valueStringBuilder.Append(currentValue.ToString());
        }

        public void UpdateTotalValue(UpdateTotalHandler updateHandler)
        {
            currentValue = Double.Parse(CurrentDisplayText);

            totalValue = updateHandler(currentValue, totalValue);
        }
    }
}
