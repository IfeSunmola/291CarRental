/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _291CarRental
{
    public class DbConnection
    {
        internal SqlConnection connection;
        internal SqlCommand command;
        internal SqlDataReader? reader;
        internal const string connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";

        internal DbConnection()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            try
            {
                connection.Open();
                command.Connection = connection;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL CONNECTION ERROR");
            }
        }

        internal int executeNonQuery(String insertQuery)
        {
            command.CommandText = insertQuery;
            return command.ExecuteNonQuery();
        }

        internal SqlDataReader executeReader(String query)
        {// gets something from the db
            command.CommandText = query;
            reader = command.ExecuteReader();
            return reader;
        }

        internal String? executeScalar(String query)
        {
            command.CommandText = query;
            var result = command.ExecuteScalar();
            if (result == null)
            {
                return null;
            }
            return result.ToString();
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _291CarRental
{
    public class DbConnection
    {
        internal SqlConnection connection;
        internal SqlCommand command;
        internal SqlDataReader? reader;
        internal const string connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";

        internal DbConnection()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            try// add using 
            {
                connection.Open();
                command.Connection = connection;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL CONNECTION ERROR (DbConnection.cs)");
            }
        }

        internal int executeNonQuery(String query)
        {
            closeReader();
            command.CommandText = query;
            return command.ExecuteNonQuery();
        }

        internal SqlDataReader executeReader(String query)
        {
            closeReader();
            command.CommandText = query;
            reader = command.ExecuteReader();
            return reader;
        }

        internal String? executeScalar(String query)
        {
            command.CommandText = query;
            closeReader();
            var result = command.ExecuteScalar();
            if (result == null)
            {
                return null;
            }
            return result.ToString();
        }

        private void closeReader()
        {
            if (reader != null)
            {
                reader.Close();
            }
        }
    }
}
