using System;
using System.Data.Common;
using System.Runtime;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAcessLayer
{
    public class SqlConnection
    {
        private static MySqlConnection CreateConnection()
        {
            MySqlConnection cnn;
            string connetionString = $"Server=vserver318.axc.eu;user=luukkpj318_backlogchecker;password=Fontys123!;Database=luukkpj318_backlogchecker";
            cnn = new MySqlConnection(connetionString);
            return cnn;
        }
    }
}
