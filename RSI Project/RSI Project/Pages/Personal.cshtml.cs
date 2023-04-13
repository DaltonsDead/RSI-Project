using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace WebApplication2.Pages
{
    public class PersonalModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public List<Skills> skills = new List<Skills>();
        
        public void OnGet()
        {
            DatabaseMethods.pullSingleEmployeeInfo(employee, email: User.Identity.Name);
            DatabaseMethods.pullEmployeeSkills(skills, employee.empIntID);
        }
    }
}
