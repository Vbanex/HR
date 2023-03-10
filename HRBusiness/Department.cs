using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRBusiness;
using HRBusiness.hrDatasetTableAdapters;

namespace HR.Business
{
    public class Department
    {
        public string Name { get; set; }
        public List<Employee> employees { get; set; }
        private int _departmentId;

        public Department() {
        employees = new List<Employee>();
        }


        public void CreateNewEmployee(string firstname, string lastname, decimal salary, string designation)
        {
            /*
            Employee employee = new Employee();
            employee.FirstName = firstname;
            employee.LastName = lastname;
            employee.Salary = salary;
            employee.Designation = designation; 
            */
            employeesTableAdapter employeesTableAdapter =  new employeesTableAdapter();
            employeesTableAdapter.CreateEmployee(firstname, lastname, salary, _departmentId, designation);

            
        }

        public void AddDepartment(string name)
        {
            departmentTableAdapter departmentTableAdapter = new departmentTableAdapter();
            departmentTableAdapter.InsertNewDepartment(name);
        }

     
            public static List<Department> GetDepartments()
        {

        
            List<Department> list= new List<Department>();
            employeesTableAdapter employeesTableAdapter = new employeesTableAdapter();
departmentTableAdapter departmentTableAdapter = new departmentTableAdapter();

            var dtDepartment = departmentTableAdapter.GetData();
            
           
            foreach (HRBusiness.hrDataset.departmentRow rows in dtDepartment.Rows )
            {
                var department = new Department();
                department.Name = rows.name;
                department._departmentId = rows.id;
                list.Add( department );
                var dtEmployee = employeesTableAdapter.GetEmployeesByDepartmentId(rows.id);
                
                foreach(HRBusiness.hrDataset.employeesRow employeesRow in dtEmployee.Rows )
                {
                    department.AddEmployee(employeesRow.firstname, employeesRow.lastname, employeesRow.salary, employeesRow.designation);
                }

            }
           return list;
            }
        

        public void AddEmployee(string FirstName, string LastName, decimal Salary, string Designation) { 
        Employee employee = new Employee();
            employee.Designation = Designation;
            employee.FirstName = FirstName; 
            employee.LastName = LastName;
            employee.Salary = Salary;
            employees.Add(employee);
        }

       
        
    }
}
