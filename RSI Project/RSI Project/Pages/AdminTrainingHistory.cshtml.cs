using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSI_Project.Classes;

namespace RSI_Project.Pages
{
    public class AdminTrainingHistoryModel : PageModel
    {
        public EmployeeInfo employee = new EmployeeInfo();
        public List<TrainingPlan> plans= new List<TrainingPlan>();
        public void OnGet()
        {
            int num = int.Parse(Request.Query["id"]);
            Console.WriteLine(num);
            employee = DatabaseMethods.EmpInfoByEmpNum(num);
            plans = DatabaseMethods.getTrainingHistory(employee.empIntID);
        }

        public void GetEmployeeTraining(int num)
        {
            string nuwm = Request.Query["id"];
            Console.WriteLine(nuwm);
            employee = DatabaseMethods.EmpInfoByEmpNum(num);
            plans = DatabaseMethods.getTrainingHistory(employee.empIntID);
        }
    }
}
