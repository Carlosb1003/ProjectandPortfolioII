using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarlosBelardo_CodeFiles
{
    class Program
    {


        static void Main(string[] args)
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=TW_Tracker;port=8889";

            MySqlConnection conn = null;


            while (true)
            {
                string title = @"_____________      __ ___________                     __                 
\__    ___/  \    /  \\__    ___/___________    ____ |  | __ ___________ 
  |    |  \   \/\/   /  |    |  \_  __ \__  \ _/ ___\|  |/ // __ \_  __ \
  |    |   \        /   |    |   |  | \// __ \\  \___|    <\  ___/|  | \/
  |____|    \__/\  /____|____|   |__|  (____  /\___  >__|_ \\___  >__|   
                 \/_____/                   \/     \/     \/    \/       
";
                Console.WriteLine(title);
                Console.WriteLine("Press Enter to Select which user you would like to use?");
                Console.ReadKey();
                Console.Clear();
                User myUser = new User();
            y:
                myUser.Login(conn);
                Console.WriteLine("Please type new if you would like to create a new user");
                string selection = Console.ReadLine().ToLower();
                myUser.UserId = selection;
                if (selection == "new")
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    Console.Write("Enter a first name:");
                    myUser.Firstname = Console.ReadLine();
                    Console.Write("Enter lastname:");
                    myUser.Lastname = Console.ReadLine();
                    Console.Write("Enter your age:");
                    myUser.Age = Console.ReadLine();

                    myUser.Save(conn, myUser.Firstname, myUser.Lastname);


                }

                int choice;
                int.TryParse(selection, out choice);
                conn = new MySqlConnection(cs);
                conn.Open();

                if (choice >= 1)
                {

                    string users = "SELECT userid, firstname, lastname FROM users WHERE userid = @user_id";
                    MySqlCommand cmd = new MySqlCommand(users, conn);
                    cmd.Parameters.AddWithValue("@user_id", selection);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        string userId = rdr["userid"].ToString();
                        string firstname = rdr["firstname"].ToString();
                        string lastname = rdr["lastname"].ToString();
                        Console.WriteLine("Hello " + firstname + " What would you like to do today?");
                    x:
                        Menu();
                        string select = Console.ReadLine().ToLower();
                        switch (select)
                        {

                            case "Record activity":
                            case "1":

                                {
                                    Console.WriteLine("Pick A Category Of Activity");
                                    Activities();
                                    string activity = Console.ReadLine();
                                    Console.Clear();
                                    myUser.Activity = activity;
                                    Console.WriteLine("Choose 1-50 What Date Did You Perform Activity ");
                                    Date();
                                    string date = Console.ReadLine();
                                    Console.Clear();
                                    myUser.Date = date;
                                    Console.WriteLine("Choose 1-96 How Long Did You Perform That Activity? ");
                                    TimeSpent();
                                    string time = Console.ReadLine();
                                    Console.Clear();
                                    myUser.TimeSpent = time;
                                    Console.WriteLine("Choose 0-50 How far did you go in miles?(If playing sport enter 0 for miles)");
                                    Distance();
                                    string distance = Console.ReadLine();
                                    Console.Clear();
                                    myUser.Distance = distance;
                                    rdr.Close();
                                    myUser.SaveData(conn);

                                    Console.WriteLine("Your activity has been tracked!");
                                    Console.WriteLine("What would you like to do next");
                                    Console.WriteLine("1. Enter another activity");
                                    Console.WriteLine("2. Back to Main Menu");
                                    Console.WriteLine("3. Select different user");
                                    string next = Console.ReadLine();
                                    int nextChoice;
                                    int.TryParse(next, out nextChoice);
                                    if (nextChoice == 1)
                                    {
                                        goto case "1";
                                    }
                                    else if (nextChoice == 2)
                                    {
                                        goto x;
                                    }
                                    else if (nextChoice == 3)
                                    {
                                        goto y;
                                    }

                                }
                                break;
                            case "view tracked data":
                            case "2":
                                {


                                    string stm = "Select users.userid, users.firstname,users.lastname,activity.activity,date.date,time.time_in_hours,distance.distance_in_miles from Tracker inner join users on Tracker.userId = users.userId inner join activity on activity.activityid = tracker.activityid inner join date on date.dateid = tracker.dateid inner join time on time.timeid = tracker.timeid inner join distance on distance.distanceid = tracker.distanceid Where users.userid = @users.user_id";
                                    cmd = new MySqlCommand(stm, conn);
                                    cmd.Parameters.AddWithValue("@users.user_id", selection);
                                    rdr.Close();
                                    rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        string userid;
                                        string activity;
                                        string date;
                                        string timeSpent;
                                        string distance;
                                        if (myUser.UserId != null)
                                        {
                                            userid = rdr["userid"].ToString();
                                            firstname = rdr["firstname"].ToString();
                                            lastname = rdr["lastname"].ToString();
                                            activity = rdr["activity"].ToString();
                                            date = rdr["date"].ToString();
                                            timeSpent = rdr["time_in_hours"].ToString();
                                            distance = rdr["distance_in_miles"].ToString();
                                            Console.WriteLine("Name: " + firstname + " " + lastname + ", Activity: " + activity + ", Date: " + date + ", Time Spent: " + timeSpent + ", Hour(s) Distance: " + distance + ", Mile(s)");
                                            goto x;
                                        }

                                    }
                                    if (myUser.Activity == null)
                                    {

                                        Console.WriteLine("No activities tracked!!!");
                                        Console.ReadKey();
                                        goto x;

                                    }
                                }
                                break;
                            case "exit":
                            case "3":
                                return;

                            default:
                                {
                                    Console.WriteLine("Command not recognized.");
                                    goto x;
                                }

                        }

                    }
                    break;

                }
                else
                {

                    Console.WriteLine("please type a valid choice\r\n");

                }
                
            }

        }
        public static void Menu()
        {
            Console.WriteLine("1. Record Activity");
            Console.WriteLine("2. View activities by user");
            Console.WriteLine("3. Exit");
        }
    
        public static void Activities()
        {

            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=TW_Tracker;port=8889";

            MySqlConnection conn = null;


            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT activityid, activity FROM activity";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Console.Write("\t" + rdr["activityid"] + " ");
                Console.WriteLine(rdr["activity"]);


            }

            rdr.Close();




        }
        public static void Date()
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=TW_Tracker;port=8889";

            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT * FROM Date Limit 50";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {


                
                Console.Write(rdr["dateid"] + ")");
                Console.Write("|");
                Console.Write(rdr["date"]);
                Console.WriteLine("|");
                




            }
            
            rdr.Close();

        }
        public static void TimeSpent()
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=TW_Tracker;port=8889";

            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT * FROM time";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {



                Console.Write(rdr["timeid"] + ")");
                Console.Write("|");
                Console.Write(rdr["time_in_hours"]);
                Console.WriteLine("|");





            }
           
            rdr.Close();

        }
        public static void Distance()
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=TW_Tracker;port=8889";

            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT * FROM Distance limit 51";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {



                Console.Write(rdr["distanceid"] + ")");
                Console.Write("|");
                Console.Write(rdr["distance_in_miles"]);
                Console.WriteLine("|");





            }

            rdr.Close();
        }

    }
}
