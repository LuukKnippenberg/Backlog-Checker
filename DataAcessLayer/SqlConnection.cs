using System;
using System.Data.Common;
using System.Runtime;
using System.Data.SqlClient;
using System.Data;

namespace DataAcessLayer
{
    public class SqlConnection
    {

        //Return a DataReader object that inherits from IDataReader
        public IDataReader GetData(IDbConnection con, string commandText) 

        {
            //Create a Command object that inherits from IDbCommand
            IDbCommand cmd = con.CreateCommand();

            //Set the CommandText to the value passed in
            cmd.CommandText = commandText;

            //Open the connection
            try

            {

                con.Open();

            }

            catch

            {
                //Connection is invalid or already open

            }

            //Return the results from ExecuteReader()
            return cmd.ExecuteReader();

        }
    }


}
