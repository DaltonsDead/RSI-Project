using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;
using System.Numerics;

namespace RSI_Project.Pages
{
    public class AdminTrainingHistoryModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public List<TrainingPlan> plans= new List<TrainingPlan>();
        public TrainingPlan activePlan = new TrainingPlan();
        public void OnGet()
        {
            int num = int.Parse(Request.Query["id"]);
            Console.WriteLine(num);
            employee = DatabaseMethods.EmpInfoByEmpNum(num);
            plans = DatabaseMethods.getTrainingHistory(employee.empIntID);
            DatabaseMethods.getActiveTrainingPlan(activePlan, employee.empIntID);

            foreach (var plan in plans)
            {
                DatabaseMethods.getMediumAndStatus(plan);
                DatabaseMethods.getPlanSkills(plan);
            }
            DatabaseMethods.getMediumAndStatus(activePlan);
            DatabaseMethods.getPlanSkills(activePlan);
        }
    }

}
