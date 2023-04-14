using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace RSI_Project.Pages
{
    public class EditPersonalModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public List<Skills> unasSkills = new List<Skills>();
        public List<Skills> skills = new List<Skills>();
        public void OnGet()
        {
            DatabaseMethods.pullSingleEmployeeInfo(employee, email: User.Identity.Name);
            DatabaseMethods.pullUnassignedSkills(unasSkills, employee.empIntID);
            DatabaseMethods.pullEmployeeSkills(skills, employee.empIntID);
        }

        [HttpPost]
        public void UpdateSkillActivity(int active)
        {

        }
    }
}
