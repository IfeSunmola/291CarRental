using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _291CarRental
{
    internal static class DatabaseConnection
    {
        private const String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private static readonly SqlConnection connection = new SqlConnection(connectionString);
        private static readonly SqlCommand command = connection.CreateCommand();

        internal static SqlCommand getCommand(String query)
        {
            connection.Open();
            command.CommandText = query;
            return command;
        }

        internal static void kThanksBye()
        {
            connection.Close();
            command.Dispose();
        }
    }
}
