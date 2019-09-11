using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EmployeeHierarchyTest
{
   
    [TestClass]
    public class ClassEmployeesTest
    {
        private const bool ResultValidationExpected = true;
        private String inputManagerId = "Employee1";
        private Double budgetAmountExpected = 2800;
        readonly string list = @"Emplyee4,Employee2,500
                        Employee3,Employee1,800
                        Employee1,,1000
                        Employee5,Employee1,500
                        Employee2,Employee1,500";
        /// <summary>
        /// Testacase for Validating CSV File
        /// The constructor should validate that:
        /// 1. The salaries in the CSV are valid integer numbers.
        /// 2. One employee does not report to more than one manager.
        /// 3. There is only one CEO, i.e.only one employee with no manager.
        /// 4. There is no circular reference, i.e.a first employee reporting to a second employee that is also under
        /// the first employee.
        /// 5. There is no manager that is not an employee, i.e.all managers are also listed in the employee column.
        /// </summary>
        [TestMethod]
        public void ClassEmployeesTests()
        {
            bool success = false;
            var test = new EmployeeHierarchy.ClassEmployees(list,ref success);
        

         Assert.AreEqual(ResultValidationExpected, success);
        }
        /// <summary>
        /// Testing the Budget for a given Manager 
        /// The salary budget from a manager is defined as the sum of the salaries of all the employees reporting(directly or indirectly)
        /// to a specified manager, plus the salary of the manager.
        /// </summary>
        [TestMethod]
        public void SalaryBudgetTests()
        {
         
            Double budgetAmountReturned;
            bool success = false;
            var test = new EmployeeHierarchy.ClassEmployees(list, ref success);
        
            budgetAmountReturned = test.SalaryBudget(inputManagerId);
            Assert.AreEqual(budgetAmountExpected, budgetAmountReturned);
        }


    }
}
