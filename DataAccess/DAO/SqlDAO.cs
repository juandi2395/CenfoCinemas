using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    /*
     * Clase u objeto que se encarga del accceso a la base de datos SQL.
     * Solo ejecuta store procedures
     * 
     * Esta clase implementa el patron de Singlenton
     * para asegurar que solo exista una instancia de la clase SqlDAO
     */

    public class SqlDAO
    {
        // Paso 1: Crear una instancia privada estática de la clase SqlDAO
        private static SqlDAO _instance;

        private string _connectionString;

        // Paso 2: Redefr el constructor como privado para evitar instanciación externa
        private SqlDAO()
        {
            _connectionString = @"Data Source=srv-sqldatabase-jgonz2395.database.windows.net;Initial Catalog=cenfocinemas-db;User ID=sysman;Password=Cenfotec123!;Trust Server Certificate=True";
        }

        // Paso 3: Crear un método público estático para obtener la instancia de la clase SqlDAO

        public static SqlDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlDAO();
            }
            return _instance;
        }

        // Metodo para la ejecución de un store procedure sin retorno

        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //Set de los parametros
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    //Ejectura el SP
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        // Metodo para la ejecución de un store procedure con retorno
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation operation)
        {
            // Conectars a la base de datos y ejecutar el store procedure
            // Capturar el resultado en una lista de diccionarios
            // Convertirlo en DTOs
            return new List<Dictionary<string, object>>();
        }
    }
}
