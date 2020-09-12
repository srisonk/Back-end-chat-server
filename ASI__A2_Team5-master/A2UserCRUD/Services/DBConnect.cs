using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace A2UserCRUD
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;
        private DataTable dataTable = new DataTable();

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            /*
            server = "localhost";
            database = "mentoringacad";
            uid = "root";
            password = "";
            
            server = "db4free.net";
            port = "3306";
            uid = "asigroup5";
            password = "asigroup5"; 
            database = "mentoringacademy";
            */
            server = "mentoringipb.mysql.database.azure.com";
            port = "3306";
            uid = "mentoring5@mentoringipb";
            password = "Mentoring.5";
            database = "mentoringacademy";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";OldGuids=true;";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public DataTable Select(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader rdr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rdr);
                return dt;
            }
            else
            {
                return null;
            }
        }

        public object RunSQL(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                return command.ExecuteScalar();
            }
            else
            {
                return null;
            }
            
        }
    }
}
