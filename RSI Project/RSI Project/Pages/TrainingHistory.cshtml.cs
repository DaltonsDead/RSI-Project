using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace RSI_Project.Pages
{
    public class TrainingModel : PageModel
    {

        public EmployeeInfo employee = new EmployeeInfo();
        public List<TrainingPlan> plans = new List<TrainingPlan>();

        public void OnGet()
        {
            employee = DatabaseMethods.pullSingleEmployeeInfo(email: User.Identity.Name);
            plans = DatabaseMethods.getTrainingHistory(employee.empIntID);

            foreach(var plan in plans)
            {
                DatabaseMethods.getMediumAndStatus(plan);
                DatabaseMethods.getPlanSkills(plan);
            }
            
        }
    }
}
