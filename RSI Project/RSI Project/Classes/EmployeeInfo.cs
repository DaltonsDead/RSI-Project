using System.Data.SqlTypes;

namespace RSI_Project.Classes
{
    public class EmployeeInfo
    {
        public int employeeID;
        public int userType;
        public int regionID;
        public int practiceArea;
        public SqlBinary inLabs;
        public string fName;
        public string lName;
        public string email;
        public int empIntID;
    }
}
