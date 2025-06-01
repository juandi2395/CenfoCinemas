using System;
using System.Collections.Generic;
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
            _connectionString = string.Empty;
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

        public void ExecuteProcedure(SqlOperation operation)
        {
            // Conectars a la base de datos y ejecutar el store procedure
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
