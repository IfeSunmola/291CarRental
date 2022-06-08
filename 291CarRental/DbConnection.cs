using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _291CarRental
{
    internal class DbConnection
    {
        internal SqlConnection connection;
        internal SqlCommand command;
        internal SqlDataReader reader;
        internal const string ConnectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";

        internal DbConnection()
        {

        }
    }
}
