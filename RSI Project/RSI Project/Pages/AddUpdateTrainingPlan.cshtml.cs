using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace RSI_Project.Pages
{
    public class AddUpdateTrainingPlanModel : PageModel
    {
        public List<Medium> media = new List<Medium>();
        public List<Status> statuses = new List<Status>();
        public EmployeeInfo employee = new EmployeeInfo();
        public TrainingPlan activeTraining = new TrainingPlan();

        public void OnGet()
        {
            media = DatabaseMethods.getMedia();
            statuses = DatabaseMethods.getStatuses();
            employee = DatabaseMethods.pullSingleEmployeeInfo(email: User.Identity.Name);
            DatabaseMethods.getActiveTrainingPlan(activeTraining, employee.empIntID);
            DatabaseMethods.getMediumAndStatus(activeTraining);
        }

        public void OnPostSave(int trainingId, int empId, int statusId, int mediumId, string description, DateTime startDate, DateTime endDate)
        {
            if(trainingId == 0)
            {
                DatabaseMethods.addTrainingPlan(empId, 1, mediumId, description, startDate, endDate, (User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@"))));
            }
            else
            {
                DatabaseMethods.updateTrainingPlan(trainingId, statusId, mediumId, description, startDate, endDate, (User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@"))));
            }
            Response.Redirect("/ViewActiveTraining");
        }
    }
}
