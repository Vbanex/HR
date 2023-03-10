namespace HRConsole
{
    using HR.Business;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main(string[] args)
        {
             List<Department> departments = Department.GetDepartments();
            /*Department newDepartment = departments[1];
            newDepartment.CreateNewEmployee("Nkechi", "Amanda", 180000, "Human Resource Person");
            departments = Department.GetDepartments();
            */
            Console.WriteLine($"List Of Employees \n");
        foreach (Department department in departments)
            {

                foreach (Employee employee in department.employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName}  {employee.Salary} {employee.Designation}\n");
                }
            }

            /*
     Department department = new Department();
     department.Name = "IT";
     department.AddEmployee("Oluwasegun","Olabamiji", 1000000, department.Name);
     department.AddEmployee("Mary", "Adudu", 100000, department.Name);
     var employees = department.GetEmployees();
     */


        }
    }
}