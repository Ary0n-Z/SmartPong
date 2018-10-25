using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartPong
{
    class Pong : INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // ?.Invoke

        // Fields
        private int playerPadY = 0;
        
        // Properties
        public int PlayerPadY
        {
            get
            {
                return playerPadY;
            }
            set
            {
                playerPadY = value;
                OnPropertyChanged("PlayerPadY");
            }
        }
        
    }
}
