using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace RSI_Project.Pages
{
    public class ViewActiveTrainingModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public TrainingPlan activeTraining  = new TrainingPlan();
        public void OnGet()
        {
            employee = DatabaseMethods.pullSingleEmployeeInfo(email: User.Identity.Name);
            DatabaseMethods.getActiveTrainingPlan(activeTraining, employee.empIntID);
            DatabaseMethods.getMediumAndStatus(activeTraining);

        }
    }
}
