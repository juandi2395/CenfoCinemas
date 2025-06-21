using DataAccess.DAO;
using DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory()
        {
            _sqlDao = SqlDAO.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            var user = baseDTO as User;
            var sqlOperation = new SqlOperation() { ProcedureName = "CRE_USER_PR" };
            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
            sqlOperation.AddStringParameter("P_Status", user.Status);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(int iD)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "DEL_USER_PR" };
            sqlOperation.Parameters.Add(new SqlParameter("P_ID", iD));

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();

            var sqlOperation = new SqlOperation() { ProcedureName = "RET_ALL_USERS_PR" };

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var user = BuildUser(row);
                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }
            return lstUsers;
        }

        public override T RetrieveById<T>(int iD)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_ID_PR" };
            sqlOperation.Parameters.Add(new SqlParameter("P_ID", iD));

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var user = BuildUser(row);
                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "UPD_USER_PR" };
            var user = baseDTO as User;
            sqlOperation.Parameters.Add(new SqlParameter("P_ID", (user.ID);
            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
            sqlOperation.AddStringParameter("P_Status", user.Status);

            var listResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);
        }

        // Metodo que convierte el dicccionario en un usuario

        private User BuildUser(Dictionary<string, object> row)
        {
            var user = new User()
            {
                ID = (int)row["Id"],
                Created = (DateTime)row["Created"],
                //Updated = (DateTime)row["Updated"], esto lo ibamos a revisar con el profe
                UserCode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                BirthDate = (DateTime)row["BirthDate"],
                Status = (string)row["Status"]
            };
            return user;
        }

        public T RetrieveByEmail<T>(User user)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_EMAIL_PR" };
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var retrievedUser = BuildUser(row);
                return (T)Convert.ChangeType(retrievedUser, typeof(T));
            }
            return default(T);
        }

        public T RetrieveByUserCode<T>(User user)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_USER_CODE_PR" };
            sqlOperation.AddStringParameter("P_CODE", user.UserCode);
            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var retrievedUser = BuildUser(row);
                return (T)Convert.ChangeType(retrievedUser, typeof(T));
            }
            return default(T);
        }
    }
}
