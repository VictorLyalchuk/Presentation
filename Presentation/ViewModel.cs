using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _img;
        public string img
        {
            get { return _img; }
            set
            {
                _img = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
