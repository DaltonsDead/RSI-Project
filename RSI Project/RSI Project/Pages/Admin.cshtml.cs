using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;
using System.Data.SqlClient;

namespace RSI_Project.Pages
{
    public class AdminModel : PageModel
    {
        public List<EmployeeInfo> employeeList = DatabaseMethods.pullAllEmployeeInfo();
        public EmployeeInfo employeeUser = new EmployeeInfo();
        public void OnGet()
        {
            DatabaseMethods.pullSingleEmployeeInfo(employeeUser, email: User.Identity.Name);
        }

        public string GetPracticeAreaName(int practiceAreaID)
        {
            try 
            {
                return DatabaseMethods.pullPracticeAreaByID(practiceAreaID).practiceAreaName;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "None";
            }
        }

        public async Task OnPostSearch(int searchID)
        {
            List<EmployeeInfo> tempList = new List<EmployeeInfo>();
            foreach(EmployeeInfo employee in employeeList)
            {
                if (searchID == employee.employeeID)
                {
                    tempList.Add(employee);
                }
            }
            if (tempList.Count > 0)
            {
                employeeList = tempList;
            }
            OnGet();
        }

        public async Task OnPostAdd(int empID)
        {
            DatabaseMethods.addEmployeeToLabs(empID);
            employeeList = DatabaseMethods.pullAllEmployeeInfo();
            OnGet();
        }
    }
}
