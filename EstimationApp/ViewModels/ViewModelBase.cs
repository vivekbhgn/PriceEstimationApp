using System;
using System.ComponentModel;

namespace EstimationApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
