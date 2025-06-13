
using DataAccess.DAO;
using System.Data.SqlTypes;

public class Program { 

    public static void Main(string[] args) 
    {
        /*var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";
        sqlOperation.AddStringParameter("P_UserCode", "juandi");
        sqlOperation.AddStringParameter("P_Name", "Juan Diego");
        sqlOperation.AddStringParameter("P_Email", "juan@test.com");
        sqlOperation.AddStringParameter("P_Password", "12345678");
        sqlOperation.AddDateTimeParam("P_BirthDate", new DateTime(1995, 9, 1));
        sqlOperation.AddStringParameter("P_Status", "AC");

        var sqlDAO = SqlDAO.GetInstance();
        sqlDAO.ExecuteProcedure(sqlOperation);*/

        var sqlOperation2 = new SqlOperation();
        sqlOperation2.ProcedureName = "CRE_MOVIE_PR";
        sqlOperation2.AddStringParameter("P_Title", "Avatar 2");
        sqlOperation2.AddStringParameter("P_Genre", "Sci-Fi");
        sqlOperation2.AddStringParameter("P_Director", "James Cameron");
        sqlOperation2.AddStringParameter("P_Description", "A sequel to the 2009 film Avatar.");
        sqlOperation2.AddDateTimeParam("P_ReleaseDate", new DateTime(2022, 12, 16));

        var sqlDAO2 = SqlDAO.GetInstance();
        sqlDAO2.ExecuteProcedure(sqlOperation2);


    }

}