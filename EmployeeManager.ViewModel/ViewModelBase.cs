using System.ComponentModel;

namespace EmployeeManager.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        protected void RaisePropertyChangedEvent(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
