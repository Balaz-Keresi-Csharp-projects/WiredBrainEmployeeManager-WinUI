using EmployeeManager.Common.DataProvider;
using EmployeeManager.Common.Model;
using System.Collections.ObjectModel;

namespace EmployeeManager.ViewModel
{
    public class MainViewModel: ViewModelBase
    {

        private EmployeeViewModel _selectedEmployee;
        private readonly IEmployeeDataProvider employeeDataProvider;
        public MainViewModel(IEmployeeDataProvider employeeDataProvider)
        {
            this.employeeDataProvider = employeeDataProvider;
        }
        public ObservableCollection<EmployeeViewModel> Employees { get; } = new();
        public ObservableCollection<JobRole> JobRoles { get; } = new();

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set 
            {
                if (_selectedEmployee != value)
                {                 
                    _selectedEmployee = value;
                    RaisePropertyChangedEvent(nameof(SelectedEmployee));
                    RaisePropertyChangedEvent(nameof(IsEmployeeSelected));
                }
            }
        }

        public bool IsEmployeeSelected => SelectedEmployee != null;

        public void Load()
        {
            var employees = employeeDataProvider.LoadEmployees();
            var jobRoles = employeeDataProvider.LoadJobRoles();

            Employees.Clear();

            foreach( var employee in employees)
            {
                Employees.Add(new EmployeeViewModel(employee, employeeDataProvider));
            }

            JobRoles.Clear();
            foreach (var jobRole in jobRoles)
            {
                JobRoles.Add(jobRole);
            }
        }
    }
}
