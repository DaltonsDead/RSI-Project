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
        public void OnGet()
        {
            DatabaseMethods.pullSingleEmployeeInfo(employee, email: User.Identity.Name);
            DatabaseMethods.pullUnassignedSkills(unasSkills, employee.empIntID);
            DatabaseMethods.pullEmployeeSkills(skills, employee.empIntID);
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
