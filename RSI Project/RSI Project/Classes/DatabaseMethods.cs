using RSI_Project.Classes;
using System.Data.SqlClient;


namespace RSI_Project.Classes
{
    public class DatabaseMethods
    {
        public List<EmployeeInfo> employeeList = new List<EmployeeInfo>();

        public static void pullAllEmployeeInfo(List<EmployeeInfo> employeeList)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand allEmployees = new SqlCommand("EXEC allEmployees", connection))
                    {
                        using (SqlDataReader reader = allEmployees.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeInfo employeeInfo = new EmployeeInfo();
                                employeeInfo.userType = reader.GetInt32(1);
                                employeeInfo.regionID = reader.GetInt32(2);
                                employeeInfo.practiceArea = reader.GetInt32(3);
                                employeeInfo.employeeID = reader.GetInt32(4);
                                employeeInfo.fName = reader.GetString(5);
                                employeeInfo.lName = reader.GetString(6);
                                employeeInfo.email = reader.GetString(7);

                                employeeList.Add(employeeInfo);


                            }
                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
