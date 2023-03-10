using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Business;
using HRBusiness;

namespace HRWPFClient
{
    class WPFVM
    {
        public List<Department> AllDepartments
        {
            get
            {
                return Department.GetDepartments();
            }

        }

        private Department _selectedDepartment = new Department();
        public Department SelectedDepartment
        {
            get {
                return _selectedDepartment;
            }
            set {
                _selectedDepartment = value;
            }
        }
  

        private List<Employee> _employees = new List<Employee>();
        public List<Employee> Employees{
            get { return _employees; }
            set { _employees = value; }
            }
    }
}
