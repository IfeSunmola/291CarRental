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
        //internal const string connectionString = "Data Source = car-rentaldb-server.database.windows.net;" + "Initial Catalog = CloudCarRental;" + "User id = IfeSunmola;" + "Password = D8gDGJ3grz9H4PK;";
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
                MessageBox.Show(ex.Message, "SQL CONNECTION ERROR (DbConnection.cs), contact your administrator");
            }
        }

        /// <summary>
        /// method to execute non query commands
        /// </summary>
        /// <param name="query"></param>
        /// <returns>the amount of rows that was affected</returns>
        internal int executeNonQuery(String query)
        {
            closeReader();// close any open reader to avoid conflicts
            command.CommandText = query;// update command text
            return command.ExecuteNonQuery();// execute the query and return the amount of rows that was affected
        }

        /// <summary>
        /// method to get multiple data from the database
        /// </summary>
        /// <param name="query"></param>
        /// <returns>SqlDataReader containing the result of the query</returns>
        internal SqlDataReader executeReader(String query)
        {
            closeReader();// close any open reader to avoid conflicts
            command.CommandText = query;// update command text
            return command.ExecuteReader();// get and return the data from the database
        }
        
        /// <summary>
        /// method to execute a query and return only one value
        /// </summary>
        /// <param name="query"></param>
        /// <returns>The result of the query</returns>
        internal String? executeScalar(String query)
        {
            closeReader();// close any open reader to avoid conflicts
            command.CommandText = query;// update commmand text
            var result = command.ExecuteScalar();// store the result in an unknown type
            if (result == null)// if the result contains null, return null
            {
                return null;
            }
            return result.ToString();// else cast to string and return
        }

        /// <summary>
        /// method to close the reader, if it wasn't closed properly in the class/form that used it
        /// </summary>
        private void closeReader()
        {
            if (reader != null)
            {
                reader.Close();
            }
        }
    }
}
