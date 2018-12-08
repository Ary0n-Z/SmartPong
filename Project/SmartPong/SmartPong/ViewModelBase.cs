using System.Collections.Generic;
using System.ComponentModel;


namespace SmartPong
{
    public class ViewModelBase : INotifyObject
    {
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
