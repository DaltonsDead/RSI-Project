using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;
using System.Data.SqlClient;

namespace RSI_Project.Pages
{
    public class AdminModel : PageModel
    {
        public List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
        public void OnGet()
        {
            DatabaseMethods.pullAllEmployeeInfo(employeeList);

        }
    }
}
