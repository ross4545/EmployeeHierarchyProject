using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EmployeeHierarchyTest
{
   
    [TestClass]
    public class UnitTest1
    {
        private const bool ResultValidationExpected = true;
        readonly string list = @"Emplyee4,Employee2,500
                        Employee3,Employee1,800
                        Employee1,,1000
                        Employee5,Employee1,500
                        Employee2,Employee1,500";
       /// <summary>
       /// Testacase for Validating CSV File
       /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            bool success = false;
            var test = new EmployeeHierarchy.ClassEmployees(list,ref success);
        

         Assert.AreEqual(ResultValidationExpected, success);
        }
        /// <summary>
        /// /Testing the Budget for a given Manager 
        /// </summary>
        [TestMethod]
        public void CalBudget()
        {
            String inputManagerId = "Employee1";
            Double budgetAmountExpected = 2800;
            Double budgetAmountReturned;
            bool success = false;
            var test = new EmployeeHierarchy.ClassEmployees(list, ref success);
        
            budgetAmountReturned = test.SalaryBudget(inputManagerId);
            Assert.AreEqual(budgetAmountExpected, budgetAmountReturned);
        }


    }
}
