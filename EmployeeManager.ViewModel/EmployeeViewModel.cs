using EmployeeManager.Common.DataProvider;
using EmployeeManager.Common.Model;
using System;
using System.ComponentModel;

namespace EmployeeManager.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly Employee _employee;
        private readonly IEmployeeDataProvider _employeeDataProvider;

        public EmployeeViewModel(Employee employee, IEmployeeDataProvider employeeDataProvider)
        {
            this._employee = employee;
            this._employeeDataProvider = employeeDataProvider;
        }

        public string FirstName
        {
            get => _employee.FirstName;
            set
            {
                if (_employee.FirstName != value)
                {
                    _employee.FirstName = value;
                    RaisePropertyChangedEvent(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => _employee.FirstName;
            set
            {
                if (_employee.FirstName != value)
                {
                    _employee.FirstName = value;
                    RaisePropertyChangedEvent(nameof(LastName));
                }
            }
        }

        public DateTimeOffset EntryDate
        {
            get => _employee.EntryDate;
            set
            {
                if (_employee.EntryDate != value)
                {
                    _employee.EntryDate = value;
                    RaisePropertyChangedEvent(nameof(EntryDate));
                }
            }
        }

        public int JobRoleId
        {
            get => _employee.JobRoleId;
            set
            {
                if (_employee.JobRoleId != value)
                {
                    _employee.JobRoleId = value;
                    RaisePropertyChangedEvent(nameof(JobRoleId));
                }
            }
        }

        public bool IsCoffeeDrinker
        {
            get => _employee.IsCoffeeDrinker;
            set
            {
                if (_employee.IsCoffeeDrinker != value)
                {
                    _employee.IsCoffeeDrinker = value;
                    RaisePropertyChangedEvent(nameof(IsCoffeeDrinker));
                }
            }
        }

        public bool CanSave() => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);

        public void Save()
        {
            _employeeDataProvider.SaveEmployee(_employee);
        }

        private void RaisePropertyChangedEvent(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
