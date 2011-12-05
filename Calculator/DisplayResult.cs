using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Calculator
{
    class DisplayResult : INotifyPropertyChanged
    {
        private string resultText;

        public string ResultText
        {
            get
            {
                return resultText;
            }
            set
            {
                if (this.resultText != value)
                {
                    resultText = value;
                    OnPropertyChanged("ResultText");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}
