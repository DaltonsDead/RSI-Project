using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;
using System.Data.SqlClient;

namespace RSI_Project.Pages
{
    public class AdminModel : PageModel
    {
        public List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
        public EmployeeInfo employeeUser = new EmployeeInfo();
        public void OnGet()
        {
            DatabaseMethods.pullAllEmployeeInfo(employeeList);
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
    }
}
