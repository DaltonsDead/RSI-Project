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
        public List<Skills> inactiveSkills = new List<Skills>();

        public void OnGet()
        {
            media = DatabaseMethods.getMedia();
            statuses = DatabaseMethods.getStatuses();
            employee = DatabaseMethods.pullSingleEmployeeInfo(email: User.Identity.Name);
            DatabaseMethods.getActiveTrainingPlan(activeTraining, employee.empIntID);
            DatabaseMethods.getMediumAndStatus(activeTraining);
            DatabaseMethods.getPlanSkills(plan: activeTraining);
            inactiveSkills = DatabaseMethods.getInactivePlanSkills(activeTraining.trainingPlanID);
        }

        public void OnPostSave(int trainingId, int empId, int statusId, int mediumId, string description, DateTime startDate, DateTime endDate)
        {
            string updater = User.Identity.Name[..User.Identity.Name.IndexOf("@")];
            if (trainingId == 0)
            {
                DatabaseMethods.addTrainingPlan(empId, 1, mediumId, description, startDate, endDate, updater);
            }
            else
            {
                DatabaseMethods.updateTrainingPlan(trainingId, statusId, mediumId, description, startDate, endDate, updater);
            }
            Response.Redirect("/ViewActiveTraining");
        }

        public async Task OnPostRemove(int skillId, int trainingPlanId)
        {

            string updater = User.Identity.Name[..User.Identity.Name.IndexOf("@")];
            DatabaseMethods.setIfPlanSkillActive(trainingPlanId, 0, skillId, updater);
            OnGet();
        }

        public async Task OnPostAdd(int skillId, int trainingPlanId)
        {
            string updater = User.Identity.Name[..User.Identity.Name.IndexOf("@")];
            DatabaseMethods.setIfPlanSkillActive(trainingPlanId, 1, skillId, updater);
            OnGet();
        }
    }
}
