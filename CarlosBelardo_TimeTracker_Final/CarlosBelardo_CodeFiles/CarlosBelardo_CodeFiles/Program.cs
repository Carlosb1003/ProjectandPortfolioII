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
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=CarlosBelardo_MDV229_Database_July;port=8889";

            MySqlConnection conn = null;


            while (true)
            {
                Users();
                string selection = Console.ReadLine();
                int choice;
                int.TryParse(selection, out choice);
                conn = new MySqlConnection(cs);
                conn.Open();

                if (choice >= 1)
                {

                    string users = "SELECT user_id, user_firstname, user_lastname FROM time_tracker_users WHERE user_id = @user_id";
                    MySqlCommand cmd = new MySqlCommand(users, conn);
                    cmd.Parameters.AddWithValue("@user_id", selection);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        string userId = rdr["user_id"].ToString();
                        string firstname = rdr["user_firstname"].ToString();
                        string lastname = rdr["user_lastname"].ToString();
                        Console.WriteLine("Hello " + firstname + " What would you like to do today?");
                        x:
                        Menu();
                        string select = Console.ReadLine().ToLower();
                        switch (select)
                        {
                            
                            case "enter activity":
                            case "1":

                                {
                                    Console.WriteLine("Pick A Category Of Activity");
                                    Activities();
                                    string activity = Console.ReadLine();                                   
                                    Console.WriteLine("Pick An Activity Description:");
                                    Descriptions();
                                    string description = Console.ReadLine();
                                    Console.WriteLine("Choose 1-26 What Date Did You Perform Activity ");
                                    Date();
                                    string date = Console.ReadLine();
                                    Console.WriteLine("How Long Did You Perform That Activity? ");
                                    string time = Console.ReadLine();
                                    Console.WriteLine("Your activity has been tracked!");
                                    Console.WriteLine("What would you like to do next");
                                    Console.WriteLine("1. Enter another activity");
                                    Console.WriteLine("2. Back to Main Menu");
                                    string next = Console.ReadLine();
                                    int nextChoice;
                                    int.TryParse(next, out nextChoice);
                                    if (nextChoice == 1)
                                    {
                                        goto case "1";
                                    }
                                    else if (nextChoice==2)
                                    {
                                        goto x;
                                    }

                                }
                                break;
                            case "view tracked data":
                            case "2":
                                {

                                    cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=CarlosBelardo_MDV229_Database_July;port=8889";
                                    conn = null;


                                    conn = new MySqlConnection(cs);
                                    conn.Open();

                                    rdr = null;
                                    Console.WriteLine("1. Select by date");
                                    Console.WriteLine("2. Select By Category");
                                    Console.WriteLine("3. Select By Description");
                                    string option = Console.ReadLine();
                                    if (option == "1")
                                    {
                                        Date();
                                        string date = Console.ReadLine();
                                        string stm = "SELECT tracked_calendar_dates.calendar_date,activity_description,activity_times.time_spent_on_activity FROM activity_log INNER JOIN tracked_calendar_dates on tracked_calendar_dates.calendar_date_id = activity_log.calendar_date INNER JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_descriptions inner join activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_log.calendar_date=@date";
                                        cmd = new MySqlCommand(stm, conn);
                                        cmd.Parameters.AddWithValue("@date", date);
                                        rdr = cmd.ExecuteReader();
                                        while (rdr.Read())
                                        {

                                            string actdate = rdr["calendar_date"].ToString();
                                            string desc = rdr["activity_description"].ToString();
                                            string times = rdr["time_spent_on_activity"].ToString();
                                            int spent;
                                            int.TryParse(times, out spent);
                                            int untracked = 24 - spent;
                                            Console.WriteLine("Activity Date: " + actdate + "| Description: " + desc + "| Time Tracked: " + times + " hour(s)| Time untracked: " + untracked + " hours");
                                            Console.WriteLine("press enter for next entry");
                                            Console.ReadKey();

                                        }
                                        Console.WriteLine("Would you like to add an event? please type yes or no");
                                        string eventdate = Console.ReadLine().ToLower();
                                        if (eventdate == "yes")
                                        {

                                            goto case "1";

                                        }
                                        else if (eventdate == "no")
                                        {
                                            goto case "2";
                                        }

                                        conn.Close();
                                    }
                                    else if (option == "2")
                                    {
                                        
                                        Console.WriteLine("Which one would you like to view?");
                                        Activities();
                                        string cat = Console.ReadLine();
                                        string stm = "SELECT activity_categories.category_description ,SUM(activity_log.time_spent_on_activity) as Time_spent FROM activity_log inner join activity_categories on activity_categories.activity_category_id = activity_log.category_description inner join activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_categories.activity_category_id=@category_id Group by activity_log.category_description ";          
                                        cmd = new MySqlCommand(stm, conn);
                                        
                                        cmd.Parameters.AddWithValue("@category_id", cat);
                                        rdr = cmd.ExecuteReader();
                                        while (rdr.Read())
                                        {

                                            string actcat = rdr["category_description"].ToString();
                                            string spent = rdr["Time_spent"].ToString();
                                            
                                            Console.WriteLine("Category: " + actcat + "| Total Time Spent: " + spent );
                                            Console.ReadKey();

                                        }

                                    }
                                    else if (option == "3")
                                    {
                                        Console.WriteLine("Which one would you like to view?");
                                        Descriptions();
                                        string desc = Console.ReadLine();
                                        string stm = "SELECT activity_categories.category_description ,activity_descriptions.activity_description ,SUM(activity_log.time_spent_on_activity) as time_spent FROM activity_log inner join activity_categories on activity_categories.activity_category_id = activity_log.category_description inner join activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_descriptions inner join activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity Where activity_descriptions.activity_description_id = @desc_id Group by activity_log.category_description; ";
                                        cmd = new MySqlCommand(stm, conn);
                                        string actcat = "";
                                        string actdesc = "";
                                        string spent = "";
                                        cmd.Parameters.AddWithValue("@desc_id", desc);
                                        rdr = cmd.ExecuteReader();
                                        while (rdr.Read())
                                        {

                                            actcat = rdr["category_description"].ToString();
                                            actdesc = rdr["activity_description"].ToString();
                                            spent = rdr["Time_spent"].ToString();
                                            

                                            Console.WriteLine("Activity Description: "+actdesc+"| Category: " + actcat + "| Total Time Spent: " + spent);
                                            Console.ReadKey();
                                           
                                        }
                                        if (String.IsNullOrWhiteSpace(actcat))
                                        {
                                            Console.WriteLine("There are no items of that description");
                                            goto case "2";
                                        }
                                        goto case "2";
                                    }
                                    else
                                    {
                                        goto case "2";
                                    }
                                }                               
                                break;                          
                            case "run calculations":
                            case "3":
                                {

                                }
                                break;                          
                            case "exit":
                            case "4":
                                return;
                            
                            default:
                                {
                                    Console.WriteLine("Command not recognized.");
                                    
                                }
                               break;


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
            Console.WriteLine("1. Enter activity");
            Console.WriteLine("2. View Tracked Data");
            Console.WriteLine("3. Run Calculations");
            Console.WriteLine("4. Exit");
        }
        public static void Users()
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=CarlosBelardo_MDV229_Database_July;port=8889";

            MySqlConnection conn = null;

            Console.WriteLine("Please Select which user you would like to use?");

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT user_id, user_firstname, user_lastname FROM time_tracker_users";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Console.Write(rdr["user_Id"] + " ");
                Console.Write(rdr["user_firstname"] + " ");
                Console.Write(rdr["user_lastname"] + " \r\n");

            }
            conn.Close();

        }
        public static void Activities()
        {

            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=CarlosBelardo_MDV229_Database_July;port=8889";

            MySqlConnection conn = null;


            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT activity_category_id, category_description FROM activity_categories";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Console.Write("\t" + rdr["activity_category_id"] + " ");
                Console.WriteLine(rdr["category_description"]);


            }

            conn.Close();




        }
        public static void Descriptions()
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=CarlosBelardo_MDV229_Database_July;port=8889";

            MySqlConnection conn = null;

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT * FROM activity_descriptions";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Console.Write("\t\t" + rdr["activity_description_id"] + " ");
                Console.WriteLine(rdr["activity_description"] + " ");


            }
            conn.Close();

        }
        public static void Date()
        {
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=CarlosBelardo_MDV229_Database_July;port=8889";

            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlDataReader rdr = null;
            string users = "SELECT * FROM tracked_calendar_dates";
            MySqlCommand cmd = new MySqlCommand(users, conn);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Console.Write("\t\t" + rdr["calendar_date_id"] + ")" +
                    " ");
                Console.WriteLine(rdr["calendar_date"] + " ");


            }
            conn.Close();

        }
        
            

    }
}
