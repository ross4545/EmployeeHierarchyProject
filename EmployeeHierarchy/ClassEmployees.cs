using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
    public class ClassEmployees
    {
        List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();

        string _employees; 
        string CeoID=string.Empty;

        // Main Method 
        static public void Main(String[] args)
        {

            Console.WriteLine("Main Method");
            Console.Read();
        }

        public ClassEmployees(String employees,ref bool success)
        {
            success = true;
            this._employees = employees;
            string[] Employees = _employees.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            if (Employees.Count() < 1)
            {
                success = false;
            }
            else
            {
                foreach (var employee in Employees)
                {


                    String[] employeedetails = employee.Split(',');
                    try
                    {
                        int value;
                        if (int.TryParse(employeedetails[2], out value))
                        {

                        }
                        else
                        {
                            success = false;
                            break;
                        }

                    }
                    catch
                    {
                        success = false;
                        break;
                    }
                    ////checking if more than one Ceo exist
                    try
                    {
                        if (string.IsNullOrEmpty(employeedetails[1]) && string.IsNullOrEmpty(this.CeoID))
                        {
                            this.CeoID = employeedetails[0];
                        }
                        else if (string.IsNullOrEmpty(employeedetails[1]))
                        {
                            success = false;
                            break;
                        }
                    }
                    catch
                    {
                        success = false;
                        break;
                    }

                    EmployeeViewModel result = employeeList.Find(x => (x.EmployeeID).Trim() == employeedetails[0].Trim());
                    if (result != null)
                    {
                        success = false;
                        break;
                    }
                    else
                    {
                        employeeList.Add(new EmployeeViewModel() { EmployeeID = employeedetails[0].Trim(), ManagerId = employeedetails[1].Trim(), Salary = employeedetails[2].Trim() });

                    }

                    // There is no manager that is not an employee, i.e.all managers are also listed in the employe

                }

                var managers = employeeList.GroupBy(x => x.ManagerId).Select(y => y.First());
                foreach (var manager in managers)
                {
                    if (manager.ManagerId != "")
                    {
                        EmployeeViewModel result = employeeList.Find(x => (x.EmployeeID).Trim() == manager.ManagerId.Trim());
                        if (result != null)
                        {

                        }
                        else
                        {
                            success = false;
                            break;
                        }
                    }
                }

                foreach (var employee in employeeList)
                {
                    EmployeeViewModel result = employeeList.Find(x => (x.EmployeeID).Trim() == employee.ManagerId.Trim());
                    if (result != null)
                    {
                        if (result.ManagerId != null) { 
                        if (result.ManagerId == employee.EmployeeID && result.EmployeeID == employee.ManagerId)
                        {
                            success = false;
                            break;
                        }
                        }
                    }

                }
            }

        }

        public Double SalaryBudget(String ManagerId)
        {
            Double salaryTotal = 0.00;
            EmployeeViewModel result = employeeList.Find(x => (x.EmployeeID).Trim() == ManagerId.Trim());
            List<EmployeeViewModel> results = employeeList.FindAll(x => x.ManagerId == ManagerId);
           

            if (results.Count() > 0)
            {


                foreach (var employee in results)
                {

                    salaryTotal += Convert.ToDouble(employee.Salary);

                }
                salaryTotal += Convert.ToDouble(result.Salary);


            }
            return salaryTotal;
        }

    }
}
