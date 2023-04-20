using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace RSI_Project.Pages
{
    public class ViewUpdateCreateActiveTrainingModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public TrainingPlan activeTraining  = new TrainingPlan();
        public void OnGet()
        {
            DatabaseMethods.pullSingleEmployeeInfo(employee, email: User.Identity.Name);
            DatabaseMethods.getActiveTrainingPlan(activeTraining, employee.empIntID);
            DatabaseMethods.getMediumAndStatus(activeTraining);

        }
    }
}
