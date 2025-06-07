
using DataAccess.DAO;
using System.Data.SqlTypes;

public class Program { 

    public static void Main(string[] args) 
    {
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";
        sqlOperation.AddStringParameter("P_UserCode", "juandi");
        sqlOperation.AddStringParameter("P_Name", "Juan Diego");
        sqlOperation.AddStringParameter("P_Email", "juan@test.com");
        sqlOperation.AddStringParameter("P_Password", "12345678");
        sqlOperation.AddDateTimeParam("P_BirthDate", new DateTime(1995, 9, 1));
        sqlOperation.AddStringParameter("P_Status", "AC");

        var sqlDAO = SqlDAO.GetInstance();
        sqlDAO.ExecuteProcedure(sqlOperation);

    }

}