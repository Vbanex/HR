using HR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Edit_Row(object sender, DataGridRowEditEndingEventArgs e)
        {
            HR.Business.Employee employee = e.Row.Item as HR.Business.Employee;

            if(employee != null && e.EditAction == DataGridEditAction.Commit && e.Row.IsNewItem)
            {
                HRWPFClient.WPFVM viewModel = (HRWPFClient.WPFVM) DataContext;
                viewModel.Employees.Add(employee);
            }



        }

        private void Save_New_Employee(object sender, RoutedEventArgs e)
        {
            HRWPFClient.WPFVM viewModel = (HRWPFClient.WPFVM)DataContext;

            if(viewModel.Employees.Any())
            {
            foreach (var employee in viewModel.Employees)
            {
                viewModel.SelectedDepartment.CreateNewEmployee(employee.FirstName, employee.LastName, employee.Salary, employee.Designation);
            }
            BindingOperations.GetBindingExpressionBase(cboDepartment, ComboBox.ItemsSourceProperty).UpdateTarget();
            }

            else
            {
                MessageBox.Show("Please enter an employee details");
            }
        }

        private void Add_Department(object sender, RoutedEventArgs e)
        {
            HRWPFClient.WPFVM viewModel = (HRWPFClient.WPFVM)DataContext;
            HR.Business.Department newDepartment = viewModel.NewDepartment as HR.Business.Department;
            if (!string.IsNullOrWhiteSpace(newDepartment.Name))
            {
                newDepartment.AddDepartment(newDepartment.Name);
                txtDept.Clear();
                BindingOperations.GetBindingExpressionBase(cboDepartment, ComboBox.ItemsSourceProperty).UpdateTarget();
            }
            else
            {
                MessageBox.Show("Please enter a valid department");
            }
            }

      
    }
}
