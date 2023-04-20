using RSI_Project.Classes;
using System.Data;
using System.Data.SqlClient;


namespace RSI_Project.Classes
{
    public class DatabaseMethods
    {

        public static List<EmployeeInfo> pullAllEmployeeInfo()
        {
            List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
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
                                employeeInfo.empIntID = reader.GetInt32(0);
                                employeeInfo.userType = reader.GetInt32(1);
                                employeeInfo.regionID = reader.GetInt32(2);
                                employeeInfo.practiceArea = reader.GetInt32(3);
                                employeeInfo.employeeID = reader.GetInt32(4);
                                employeeInfo.fName = reader.GetString(5);
                                employeeInfo.lName = reader.GetString(6);
                                employeeInfo.email = reader.GetString(7);
                                employeeInfo.inLabs = reader.GetSqlBinary(8);

                                employeeList.Add(employeeInfo);


                            }
                            
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employeeList;
        }

        public static EmployeeInfo pullSingleEmployeeInfo(string email)
        {
            EmployeeInfo employee = new EmployeeInfo();
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand selectEmployeeByEmail = new SqlCommand("selectByEmail", connection))
                    {
                        selectEmployeeByEmail.CommandType = CommandType.StoredProcedure;
                        selectEmployeeByEmail.Parameters.Add(new SqlParameter("@email", email));
                        using (SqlDataReader reader = selectEmployeeByEmail.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employee.empIntID = reader.GetInt32(0);
                                employee.userType = reader.GetInt32(1);
                                employee.regionID = reader.GetInt32(2);
                                employee.practiceArea = reader.GetInt32(3);
                                employee.employeeID = reader.GetInt32(4);
                                employee.fName = reader.GetString(5);
                                employee.lName = reader.GetString(6);
                                employee.email = reader.GetString(7);
                                employee.inLabs = reader.GetSqlBinary(8);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employee;
        }

        public static List<PracticeArea> pullPracticeAreas()
        {
            List<PracticeArea> practiceAreas = new List<PracticeArea>();
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand allPracticeAreas = new SqlCommand("allPracticeAreas", connection))
                    {
                        allPracticeAreas.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = allPracticeAreas.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PracticeArea practiceArea = new PracticeArea();
                                practiceArea.practiceAreaID = reader.GetInt32(0);
                                practiceArea.practiceAreaName = reader.GetString(1);

                                practiceAreas.Add(practiceArea);
                            }
                        }
                    }
                    connection.Close();
                    return practiceAreas;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return practiceAreas;
            }
        }

        public static PracticeArea pullPracticeAreaByID(int ID)
        {
            PracticeArea practiceArea = new PracticeArea();
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand practiceAreaByID = new SqlCommand("selectPracticeAreaByID", connection))
                    {
                        practiceAreaByID.CommandType = CommandType.StoredProcedure;
                        practiceAreaByID.Parameters.Add(new SqlParameter("@practiceAreaID", ID));
                        using (SqlDataReader reader = practiceAreaByID.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                practiceArea.practiceAreaID = reader.GetInt32(0);
                                practiceArea.practiceAreaName = reader.GetString(1);
                            }
                        }
                    }
                    connection.Close();
                    return practiceArea;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return practiceArea;
            }

        }
        public static void pullEmployeeSkills(List<Skills> skillList, int ID)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand selectSkillsByID = new SqlCommand("selectSkillsByID", connection))
                    {
                        selectSkillsByID.CommandType = CommandType.StoredProcedure;
                        selectSkillsByID.Parameters.Add(new SqlParameter("@ID", ID));
                        using (SqlDataReader reader = selectSkillsByID.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Skills skills = new Skills();
                                skills.skillID = reader.GetInt32(0);
                                skills.skillName = reader.GetString(1);
                                skills.empSkillId = reader.GetInt32(2);

                                skillList.Add(skills);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void pullUnassignedSkills(List<Skills> skillList, int ID)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand selectUnassignedSkills = new SqlCommand("getUnassignedSkills", connection))
                    {
                        selectUnassignedSkills.CommandType = CommandType.StoredProcedure;
                        selectUnassignedSkills.Parameters.Add(new SqlParameter("@ID", ID));
                        using (SqlDataReader reader = selectUnassignedSkills.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Skills skills = new Skills();
                                skills.skillID = reader.GetInt32(0);
                                skills.skillName = reader.GetString(1);

                                skillList.Add(skills);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static int setIfSkillActive(int active, int skillId, int empId, string updater)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand setIfActive = new SqlCommand("setIfSkillActive", connection);
                    setIfActive.CommandType = CommandType.StoredProcedure;
                    setIfActive.Parameters.Add(new SqlParameter("@skillId", skillId));
                    setIfActive.Parameters.Add(new SqlParameter("@empId", empId));
                    setIfActive.Parameters.Add(new SqlParameter("@active", active));
                    setIfActive.Parameters.Add(new SqlParameter("@updater", updater));
                    setIfActive.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public static void addEmployeeToLabs(int empID)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand addEmployeeToLabs = new SqlCommand("addEmployeeToLabs", connection);
                    addEmployeeToLabs.CommandType = CommandType.StoredProcedure;
                    addEmployeeToLabs.Parameters.Add(new SqlParameter("@empID", empID));
                    addEmployeeToLabs.ExecuteNonQuery();
                    connection.Close(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void updatePracticeArea(int empId, int practiceAreaId)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand updateEmployeePracticeArea = new SqlCommand("updateEmployeePracticeArea", connection);
                    updateEmployeePracticeArea.CommandType = CommandType.StoredProcedure;
                    updateEmployeePracticeArea.Parameters.Add(new SqlParameter("@empId", empId));
                    updateEmployeePracticeArea.Parameters.Add(new SqlParameter("@practiceAreaId", practiceAreaId));
                    updateEmployeePracticeArea.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void updateEmployeeName(string fName, string lName, int empId)
        {
            try
            {
                String connectionString = "Data Source=rsiproject1.database.windows.net;Initial Catalog=RSIproject;Persist Security Info=True;User ID=RSIadmin;Password=fuckSQL1!";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand updateEmployeeName = new SqlCommand("UpdateEmployeeName", connection);
                    updateEmployeeName.CommandType = CommandType.StoredProcedure;
                    updateEmployeeName.Parameters.Add(new SqlParameter("@employeeID", empId));
                    updateEmployeeName.Parameters.Add(new SqlParameter("@firstName", fName));
                    updateEmployeeName.Parameters.Add(new SqlParameter("@lastName", lName));
                    updateEmployeeName.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
