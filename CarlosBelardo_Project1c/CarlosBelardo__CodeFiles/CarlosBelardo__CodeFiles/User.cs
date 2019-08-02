using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarlosBelardo_CodeFiles
{
    public class User
    {
        
        public string UserId;
        public string Firstname;
        public string Lastname;
        public string Age;
        public string Activity;
        public string Date;
        public string TimeSpent;
        public string Distance;
        public string Id;
        
       public void Login(MySqlConnection conn)
        {

            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=TW_Tracker;port=8889";

             conn = null;


            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT userid, firstname, lastname FROM users";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Console.Write(rdr["userId"] + " ");
                Console.Write(rdr["firstname"] + " ");
                Console.Write(rdr["lastname"] + " \r\n");

            }
            
            rdr.Close();
        }

        public void Save(MySqlConnection conn, string firstname, string lastname)
        {
            string stm = "INSERT INTO users (firstname, lastname, age) VALUES (@firstname, @lastname,@age)";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            
            this.UserId =null ;           
            cmd.Parameters.AddWithValue("@firstname", this.Firstname);
            cmd.Parameters.AddWithValue("@lastname", this.Lastname);
            cmd.Parameters.AddWithValue("@age", this.Age);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

        }
        public void SaveData(MySqlConnection conn)
        {
            string stm = "INSERT INTO Tracker (userId,dateid,activityid,timeid,distanceid) VALUES (@userId,@dateID,@activityid,@timeid,@distanceid)";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            
            this.Id = null;
            cmd.Parameters.AddWithValue("@userId", this.UserId);
            cmd.Parameters.AddWithValue("@dateid", this.Date);
            cmd.Parameters.AddWithValue("@activityid", this.Activity);
            cmd.Parameters.AddWithValue("@timeid", this.TimeSpent);
            cmd.Parameters.AddWithValue("distanceid", this.Distance);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();


        }
       










    }
}
