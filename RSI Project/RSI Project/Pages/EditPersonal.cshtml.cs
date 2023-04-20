using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;
using System;

namespace RSI_Project.Pages
{
    public class EditPersonalModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public List<Skills> unasSkills = new List<Skills>();
        public List<Skills> skills = new List<Skills>();
        public List<PracticeArea> practiceAreas = DatabaseMethods.pullPracticeAreas();

        public void OnGet()
        {
            employee = DatabaseMethods.pullSingleEmployeeInfo(email: User.Identity.Name);
            DatabaseMethods.pullUnassignedSkills(unasSkills, employee.empIntID);
            DatabaseMethods.pullEmployeeSkills(skills, employee.empIntID);
        }

        public async Task OnPostName(string fName, string lName, int empId)
        {
            DatabaseMethods.updateEmployeeName(fName, lName, empId);
            OnGet();
        }

        public async Task OnPostArea(int empId, int practiceAreaId)
        {
            DatabaseMethods.updatePracticeArea(empId, practiceAreaId);
            OnGet();
        }


        public async Task OnPostRemove(int skillId, int empId)
        {

            string updater = User.Identity.Name[..User.Identity.Name.IndexOf("@")];
            DatabaseMethods.setIfSkillActive(0, skillId, empId, updater);
            OnGet();
        }

        public async Task OnPostAdd(int skillId, int empId)
        {
            string updater = User.Identity.Name[..User.Identity.Name.IndexOf("@")];
            DatabaseMethods.setIfSkillActive(1, skillId, empId, updater);
            OnGet();
        }
    }
}
