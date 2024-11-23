using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.FileStreamFolder
{
    public class SqlModel
    {

        public static DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("Images");
            SqlConnection sqlConnection = new SqlConnection("data source=192.168.147.54\\LOL;initial catalog=Images;user id=kek;password=arbidol;MultipleActiveResultSets=True;App=EntityFramework&quot;\" providerName=\"System.Data.EntityClient");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
