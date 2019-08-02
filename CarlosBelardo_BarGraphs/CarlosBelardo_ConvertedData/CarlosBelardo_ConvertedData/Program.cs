using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Timers;

namespace CarlosBelardo_ConvertedData
{
    class Program
    {
        //fields
        static string Id;
        public static string RestaurantName;
        static string Address;
        static string Phone;
        static string HoursOfOperation;
        static string Price;
        static string USACityLocation;
        static string Cuisine;
        static string FoodRating;
        static string ServiceRating;
        static string AmbienceRating;
        static string ValueRating;
        static string OverallRating;
        static string OverallPossibleRating;
        private static System.Timers.Timer myAnimationTimer;
        static int myTimerCount = 0;


        static void Main(string[] args)
        {

            //Database Location
            string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            string _directory = @"../../output/";


            //creating a directory
            Directory.CreateDirectory(_directory);
            while (true)
            {
                //show the menu
                PrintMenu();

                //get user input
                string selection = Console.ReadLine();
                selection = selection.ToLower();

                //handle user input
                //switch statement
                switch (selection)
                {

                    //case to convert restaurant data
                    case "convert the restaurant profile table from sql to json":
                    case "1":
                        {



                            try
                            {
                                //creating connection
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT id, RestaurantName, Address, Phone, HoursOfOperation, Price, USACityLocation, Cuisine, FoodRating, ServiceRating, AmbienceRating, ValueRating, OverallRating, OverallPossibleRating  FROM RestaurantProfiles";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();

                                if (rdr.HasRows)
                                {
                                    //creating a list for a data
                                    List<Program> data = new List<Program>();

                                    while (rdr.Read())
                                    {

                                        Program Converted = new Program();
                                        //adding fields to list from database
                                        Id = rdr["id"].ToString();
                                        RestaurantName = rdr["RestaurantName"].ToString();
                                        Address = rdr["Address"].ToString();
                                        Phone = rdr["Phone"].ToString();
                                        HoursOfOperation = rdr["HoursOfOperation"].ToString();
                                        Price = rdr["Price"].ToString();
                                        USACityLocation = rdr["USACityLocation"].ToString();
                                        Cuisine = rdr["Cuisine"].ToString();
                                        FoodRating = rdr["FoodRating"].ToString();
                                        ServiceRating = rdr["ServiceRating"].ToString();
                                        AmbienceRating = rdr["AmbienceRating"].ToString();
                                        ValueRating = rdr["ValueRating"].ToString();
                                        OverallRating = rdr["OverallRating"].ToString();
                                        OverallPossibleRating = rdr["OverallPossibleRating"].ToString();
                                        data.Add(Converted);

                                        //do/while loop to add each set of data to json file
                                        int i = 0;
                                        do
                                        {
                                            string[] lines = { "{\r\n"+"\""+"RestaurantProfiles"+"\""+":"+"["+
                                                "\""+Id + "\"," + "\t\n" +"\"" +RestaurantName+"\"," +"\r\n"+
                                                "\""+Address +"\"," + "\r\n"+"\"" + Phone +"\"," + "\r\n" +
                                                "\""+HoursOfOperation +"\"," + "\r\n" +"\""+ Price +"\"," + "\r\n" +
                                                "\""+USACityLocation +"\"," + "\r\n" +"\""+ Cuisine +"\"," + "\r\n" +
                                                "\""+FoodRating +"\"," + "\r\n"+"\"" + ServiceRating +"\"," + "\r\n" +
                                                "\""+AmbienceRating +"\"," + "\r\n"+"\"" + ValueRating +"\"," + "\r\n" +
                                               "\""+ OverallRating + "\"," +"\r\n"+"\"" + OverallPossibleRating +"\""+ "\r\n]"+"\r\n}" };
                                            i++;
                                            //adding each set of data to JSON file
                                            File.AppendAllLines(@"../../output/CarlosBelardo_ConvertedData.json", lines);




                                        } while (i < 1);





                                    }


                                    //displaying to user sussful completion of comversion
                                    Console.WriteLine("Conversion Complete");
                                    //displaying file path for JSON file
                                    string fileName = "CarlosBelardo_ConvertedData.json";
                                    string fullPath;
                                    fullPath = Path.GetFullPath(fileName);
                                    Console.WriteLine("File Located in " + fullPath);
                                }

                                rdr.Close();







                            }
                            catch (Exception ex)
                            {
                                //catching exceptions
                                Console.WriteLine("Exception occured: " + ex.ToString());
                            }

                        }
                        break;
                    //Case to display restaurant ratings
                    case "showcase our 5 star rating system":
                    case "2":
                        {
                            Console.Clear();
                            //retrieving user name
                            Console.WriteLine("Please type your name so I can address you properly");
                            string name = Console.ReadLine();
                            //displaying sorting menu options
                            Console.WriteLine("Hello " + name + ", How would you like to sort the data: ");
                            Console.WriteLine("1. List Restaurants Alphabetically (Show Rating Next To Name)");
                            Console.WriteLine("2. List Restaurants in Reverse Alphabetical (Show Rating Next To Name)");
                            Console.WriteLine("3. Sort Restaurants From Best to Worst (Show Rating Next To Name)");
                            Console.WriteLine("4. Sort Restaurants From Worst to Best (Show Rating Next To Name)");
                            Console.WriteLine("5. Show Only X-stars rated and Up");
                            string select = Console.ReadLine();
                            int choice;
                            int.TryParse(select, out choice);
                            //separating each option from the menu using a conditional
                            if (choice == 1)
                            {
                                //retrieving names alphabetically
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles  ORDER BY RestaurantName ASC;";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    OverallRating = rdr["OverallRating"].ToString();
                                    string rate = "";

                                    //displaying rating using * and code padding
                                    if (OverallRating == "0.50")
                                    {

                                        rate = OverallRating.PadRight(5, ' ');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");

                                    }
                                    else if (OverallRating == "1.00")
                                    {
                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "1.25")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "1.50")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "1.75")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "2.00")
                                    {
                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "2.25")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "2.50")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "2.75")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "3.00")
                                    {
                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "3.25")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "3.50")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "3.75")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "4.00")
                                    {
                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "4.25")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "4.50")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "4.75")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "5.00")
                                    {

                                        rate = OverallRating.PadRight(9, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else
                                    {

                                        rate = OverallRating;
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }




                                }
                                Console.WriteLine("Press Space to return to main menu");
                                Console.ReadKey();
                            }
                            else if (choice == 2)
                            {
                                //displaying restaurant names reverse alphabetically 
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles  ORDER BY RestaurantName DESC;";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    OverallRating = rdr["OverallRating"].ToString();

                                    string rate = "";

                                    //using code padding to display rating in "stars" as *
                                    if (OverallRating == "0.50")
                                    {

                                        rate = OverallRating.PadRight(5, ' ');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");

                                    }
                                    else if (OverallRating == "1.00")
                                    {
                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "1.25")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "1.50")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "1.75")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "2.00")
                                    {
                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "2.25")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "2.50")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "2.75")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "3.00")
                                    {
                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "3.25")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "3.50")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "3.75")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "4.00")
                                    {
                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "4.25")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "4.50")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "4.75")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "5.00")
                                    {

                                        rate = OverallRating.PadRight(9, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else
                                    {

                                        rate = OverallRating;
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }



                                }
                                Console.WriteLine("Press Space to return to main menu");
                                Console.ReadKey();
                            }
                            else if (choice == 3)
                            {
                                //displaying restaurants by rating from best to worst
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles  ORDER BY OverallRating DESC;";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    OverallRating = rdr["OverallRating"].ToString();

                                    string rate = "";

                                    //using code padding to display rating in "stars" as *
                                    if (OverallRating == "0.50")
                                    {

                                        rate = OverallRating.PadRight(5, ' ');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");

                                    }
                                    else if (OverallRating == "1.00")
                                    {
                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "1.25")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "1.50")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "1.75")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "2.00")
                                    {
                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "2.25")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "2.50")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "2.75")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "3.00")
                                    {
                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "3.25")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "3.50")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "3.75")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "4.00")
                                    {
                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "4.25")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "4.50")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "4.75")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "5.00")
                                    {

                                        rate = OverallRating.PadRight(9, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else
                                    {

                                        rate = OverallRating;
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }


                                }
                                Console.WriteLine("Press Space to return to main menu");
                                Console.ReadKey();

                            }
                            else if (choice == 4)
                            {
                                //displaying restaurant ratings from worst to best
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles  ORDER BY OverallRating ASC;";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    OverallRating = rdr["OverallRating"].ToString();

                                    string rate = "";

                                    //using code padding to display rating in "stars" as *
                                    if (OverallRating == "0.50")
                                    {

                                        rate = OverallRating.PadRight(5, ' ');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");

                                    }
                                    else if (OverallRating == "1.00")
                                    {
                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "1.25")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "1.50")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "1.75")
                                    {

                                        rate = OverallRating.PadRight(5, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "2.00")
                                    {
                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "2.25")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "2.50")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "2.75")
                                    {

                                        rate = OverallRating.PadRight(6, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "3.00")
                                    {
                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "3.25")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "3.50")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "3.75")
                                    {

                                        rate = OverallRating.PadRight(7, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "4.00")
                                    {
                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else if (OverallRating == "4.25")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/4\r\n");
                                    }
                                    else if (OverallRating == "4.50")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("1/2\r\n");
                                    }
                                    else if (OverallRating == "4.75")
                                    {

                                        rate = OverallRating.PadRight(8, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                        Console.Write("3/4\r\n");
                                    }
                                    else if (OverallRating == "5.00")
                                    {

                                        rate = OverallRating.PadRight(9, '*');
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }
                                    else
                                    {

                                        rate = OverallRating;
                                        Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                    }


                                }

                                Console.WriteLine("Press Space to return to main menu");
                                Console.ReadKey();
                            }
                            else if (choice == 5)
                            {
                                //submenu created for selecting restaurants based off of star rating
                                Console.WriteLine("1. Show the Best (5 Stars)");
                                Console.WriteLine("2. Show 4 Stars and Up");
                                Console.WriteLine("3. Show 3 Stars and Up");
                                Console.WriteLine("4. Show the Worst (1 Stars)");
                                Console.WriteLine("5. Show Unrated");
                                Console.WriteLine("6. Back");
                                string sub = Console.ReadLine();
                                //displaying and separating each restaurant based off of star rating
                                if (sub == "1")
                                {
                                    MySqlConnection conn = new MySqlConnection(cs);
                                    conn.Open();
                                    string stm = "SELECT RestaurantName,OverallRating FROM RestaurantProfiles WHERE OverallRating ='5.00'" +
                                        " ORDER BY RestaurantName ASC;";
                                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                                    MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        RestaurantName = rdr["RestaurantName"].ToString();
                                        OverallRating = rdr["OverallRating"].ToString();
                                        string rate = "";


                                        if (OverallRating == "0.50")
                                        {

                                            rate = OverallRating.PadRight(5, ' ');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");

                                        }
                                        else if (OverallRating == "1.00")
                                        {
                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "1.25")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "1.50")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "1.75")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "2.00")
                                        {
                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "2.25")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "2.50")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "2.75")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "3.00")
                                        {
                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "3.25")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "3.50")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "3.75")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "4.00")
                                        {
                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "4.25")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "4.50")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "4.75")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "5.00")
                                        {

                                            rate = OverallRating.PadRight(9, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else
                                        {

                                            rate = OverallRating;
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }


                                    }
                                    Console.WriteLine("Press Space to return to main menu");
                                    Console.ReadKey();
                                }
                                else if (sub == "2")
                                {
                                    MySqlConnection conn = new MySqlConnection(cs);
                                    conn.Open();
                                    string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles WHERE OverallRating >='4.00'&& OverallRating<'5.00' ORDER BY RestaurantName ASC;";
                                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                                    MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        RestaurantName = rdr["RestaurantName"].ToString();
                                        OverallRating = rdr["OverallRating"].ToString();
                                        string rate = "";


                                        if (OverallRating == "0.50")
                                        {

                                            rate = OverallRating.PadRight(5, ' ');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");

                                        }
                                        else if (OverallRating == "1.00")
                                        {
                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "1.25")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "1.50")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "1.75")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "2.00")
                                        {
                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "2.25")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "2.50")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "2.75")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "3.00")
                                        {
                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "3.25")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "3.50")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "3.75")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "4.00")
                                        {
                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "4.25")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "4.50")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "4.75")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "5.00")
                                        {

                                            rate = OverallRating.PadRight(9, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else
                                        {

                                            rate = OverallRating;
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }

                                    }
                                    Console.WriteLine("Press Space to return to main menu");
                                    Console.ReadKey();

                                }
                                else if (sub == "3")
                                {
                                    MySqlConnection conn = new MySqlConnection(cs);
                                    conn.Open();
                                    string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles WHERE OverallRating >='3.00'&& OverallRating<'4.00' ORDER BY RestaurantName ASC;";
                                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                                    MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        RestaurantName = rdr["RestaurantName"].ToString();
                                        OverallRating = rdr["OverallRating"].ToString();
                                        string rate = "";


                                        if (OverallRating == "0.50")
                                        {

                                            rate = OverallRating.PadRight(5, ' ');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");

                                        }
                                        else if (OverallRating == "1.00")
                                        {
                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "1.25")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "1.50")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "1.75")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "2.00")
                                        {
                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "2.25")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "2.50")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "2.75")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "3.00")
                                        {
                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "3.25")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "3.50")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "3.75")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "4.00")
                                        {
                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "4.25")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "4.50")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "4.75")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "5.00")
                                        {

                                            rate = OverallRating.PadRight(9, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else
                                        {

                                            rate = OverallRating;
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }


                                    }
                                    Console.WriteLine("Press Space to return to main menu");
                                    Console.ReadKey();
                                }
                                else if (sub == "4")
                                {
                                    MySqlConnection conn = new MySqlConnection(cs);
                                    conn.Open();
                                    string stm = "SELECT  RestaurantName,OverallRating FROM RestaurantProfiles WHERE OverallRating ='1.00' ORDER BY RestaurantName ASC;;";
                                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                                    MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        RestaurantName = rdr["RestaurantName"].ToString();
                                        OverallRating = rdr["OverallRating"].ToString();
                                        string rate = "";


                                        if (OverallRating == "0.50")
                                        {

                                            rate = OverallRating.PadRight(5, ' ');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");

                                        }
                                        else if (OverallRating == "1.00")
                                        {
                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "1.25")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "1.50")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "1.75")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "2.00")
                                        {
                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "2.25")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "2.50")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "2.75")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "3.00")
                                        {
                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "3.25")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "3.50")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "3.75")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "4.00")
                                        {
                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "4.25")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "4.50")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "4.75")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "5.00")
                                        {

                                            rate = OverallRating.PadRight(9, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else
                                        {

                                            rate = OverallRating;
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }


                                    }
                                    Console.WriteLine("Press Space to return to main menu");
                                    Console.ReadKey();
                                }
                                else if (sub == "5")
                                {
                                    MySqlConnection conn = new MySqlConnection(cs);
                                    conn.Open();
                                    string stm = "SELECT RestaurantName,OverallRating FROM RestaurantProfiles WHERE OverallRating IS NULL" +
                                        " ORDER BY RestaurantName ASC;";
                                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                                    MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        RestaurantName = rdr["RestaurantName"].ToString();
                                        OverallRating = rdr["OverallRating"].ToString();
                                        string rate = "";


                                        if (OverallRating == "0.50")
                                        {

                                            rate = OverallRating.PadRight(5, ' ');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");

                                        }
                                        else if (OverallRating == "1.00")
                                        {
                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "1.25")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "1.50")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "1.75")
                                        {

                                            rate = OverallRating.PadRight(5, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "2.00")
                                        {
                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "2.25")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "2.50")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "2.75")
                                        {

                                            rate = OverallRating.PadRight(6, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "3.00")
                                        {
                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "3.25")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "3.50")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "3.75")
                                        {

                                            rate = OverallRating.PadRight(7, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "4.00")
                                        {
                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else if (OverallRating == "4.25")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/4\r\n");
                                        }
                                        else if (OverallRating == "4.50")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("1/2\r\n");
                                        }
                                        else if (OverallRating == "4.75")
                                        {

                                            rate = OverallRating.PadRight(8, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate);
                                            Console.Write("3/4\r\n");
                                        }
                                        else if (OverallRating == "5.00")
                                        {

                                            rate = OverallRating.PadRight(9, '*');
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }
                                        else
                                        {

                                            rate = OverallRating;
                                            Console.Write("Name: " + RestaurantName + " ||Rating: " + rate + "\r\n");
                                        }

                                    }
                                    Console.WriteLine("Press Space to return to main menu");
                                    Console.ReadKey();
                                }
                                else if (sub == "6")
                                {

                                    goto case "2";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please choose 1-5, press enter to return to menu");
                                Console.ReadKey();
                                goto case "2";
                            }
                        }
                        break;
                    case "showcase our animated bar graph review system":
                    case "3":
                        {
                            Console.Clear();
                            //retrieving user name
                            Console.WriteLine("Please type your name so I can address you properly");
                            string name = Console.ReadLine();
                            //displaying sorting menu options
                            Console.WriteLine("Hello " + name + ", How would you like to sort the data: ");
                            Console.WriteLine("1. Show Average of Reviews for Restaurants ");
                            Console.WriteLine("2. Dinner Spinner (Selects Random Restaurant)");
                            Console.WriteLine("3. Top 10 Restaurants");
                            Console.WriteLine("4. Back To Main Menu");
                            string select = Console.ReadLine();
                            int choice;
                            int.TryParse(select, out choice);
                            if (choice == 1)
                            {
                                //retrieving names alphabetically
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT Restaurantprofiles.RestaurantName,Count(ReviewScore) From RestaurantReviews inner join RestaurantProfiles on RestaurantProfiles.id = RestaurantReviews.Restaurantid Where ReviewColor ='GREEN' Group by RestaurantProfiles.ID ASC ";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                Console.WriteLine("Press enter to select next restaurant");
                                while (rdr.Read())
                                {
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    string PosReview = rdr["COUNT(ReviewScore)"].ToString();
                                    double review;
                                    double.TryParse(PosReview, out review);
                                    Console.WriteLine(RestaurantName + " " + review + "/100");
                                    if (review <= 30)
                                    {
                                        int myTimerCount = 0;

                                        var myBackgroundColor = ConsoleColor.White;
                                        var myBarGraphColor = ConsoleColor.Red;
                                        var consolecolor = ConsoleColor.Black;
                                        myTimerCount++;
                                        Console.BackgroundColor = myBarGraphColor;


                                        double rating = review;


                                        for (int i = 0; i <= rating; i++)
                                        {

                                            Console.Write(" ");
                                        }
                                        int totalnumber = 100;
                                        Console.BackgroundColor = myBackgroundColor;
                                        for (double ii = rating; ii <= totalnumber; ii++)
                                        {
                                            Console.Write(" ");
                                        }
                                        Console.CursorLeft = 0;
                                        if (myTimerCount == 50)
                                        {


                                        }
                                        for (int x = 0; x < 1; x++)
                                        {
                                            Console.WriteLine("");
                                        }
                                        Console.BackgroundColor = consolecolor;
                                    }
                                    else if (review >= 31 || review <= 69)
                                    {
                                        int myTimerCount = 0;

                                        var myBackgroundColor = ConsoleColor.White;
                                        var myBarGraphColor = ConsoleColor.Yellow;
                                        var consolecolor = ConsoleColor.Black;
                                        myTimerCount++;
                                        Console.BackgroundColor = myBarGraphColor;


                                        double rating = review;


                                        for (int i = 0; i <= rating; i++)
                                        {

                                            Console.Write(" ");
                                        }
                                        int totalnumber = 100;
                                        Console.BackgroundColor = myBackgroundColor;
                                        for (double ii = rating; ii <= totalnumber; ii++)
                                        {
                                            Console.Write(" ");
                                        }
                                        Console.CursorLeft = 0;
                                        if (myTimerCount == 50)
                                        {


                                        }
                                        for (int x = 0; x < 1; x++)
                                        {
                                            Console.WriteLine("");
                                        }
                                        Console.BackgroundColor = consolecolor;
                                    }

                                }


                            }

                            else if (choice == 2)
                            {

                                Timer.Bar();
                            }
                            else if (choice == 3)
                            {
                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                string stm = "SELECT Restaurantprofiles.RestaurantName,AVG(ReviewScore) From RestaurantReviews inner join RestaurantProfiles on RestaurantProfiles.id = RestaurantReviews.Restaurantid Group by RestaurantProfiles.ID Order by AVG(ReviewScore) DESC LIMIT 10 ; ";
                                MySqlCommand cmd = new MySqlCommand(stm, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                Console.WriteLine("Press enter to select next restaurant");
                                while (rdr.Read())
                                {
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    string PosReview = rdr["AVG(ReviewScore)"].ToString();
                                    double review;
                                    double.TryParse(PosReview, out review);
                                    Console.WriteLine(RestaurantName + " " + review + "/100");
                                    if (review <= 30)
                                    {
                                        
                                        int myTimerCount = 0;
                                        SetTimer();
                                        Console.ReadLine();
                                        var myBackgroundColor = ConsoleColor.White;
                                        var myBarGraphColor = ConsoleColor.Red;
                                        var consolecolor = ConsoleColor.Black;
                                        myTimerCount++;
                                        Console.BackgroundColor = myBarGraphColor;


                                        double rating = review;


                                        for (int i = 0; i <= rating; i++)
                                        {

                                            Console.Write(" ");
                                        }
                                        int totalnumber = 100;
                                        Console.BackgroundColor = myBackgroundColor;
                                        for (double ii = rating; ii <= totalnumber; ii++)
                                        {
                                            Console.Write(" ");
                                        }
                                        Console.CursorLeft = 0;
                                        if (myTimerCount == 50)
                                        {


                                        }
                                        for (int x = 0; x < 1; x++)
                                        {
                                            Console.WriteLine("");
                                        }
                                        Console.BackgroundColor = consolecolor;
                                    }
                                    else if (review >= 31 || review <= 69)
                                    {
                                        int myTimerCount = 0;

                                        var myBackgroundColor = ConsoleColor.White;
                                        var myBarGraphColor = ConsoleColor.Yellow;
                                        var consolecolor = ConsoleColor.Black;
                                        myTimerCount++;
                                        Console.BackgroundColor = myBarGraphColor;


                                        double rating = review;


                                        for (int i = 0; i <= rating; i++)
                                        {

                                            Console.Write(" ");
                                        }
                                        int totalnumber = 100;
                                        Console.BackgroundColor = myBackgroundColor;
                                        for (double ii = rating; ii <= totalnumber; ii++)
                                        {
                                            Console.Write(" ");
                                        }
                                        Console.CursorLeft = 0;
                                        if (myTimerCount == 50)
                                        {


                                        }
                                        for (int x = 0; x < 1; x++)
                                        {
                                            Console.WriteLine("");
                                        }
                                        Console.BackgroundColor = consolecolor;
                                    }
                                    else if (choice == 4)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("Please choose 1-5, press enter to return to menu");
                                        Console.ReadKey();
                                        goto case "3";
                                    }
                                }
                            }
                        }
                        break;
                    //for future assignment
                    case "play a card game":
                    case "4":
                        {

                        }
                        break;
                    //case to exit
                    case "exit":
                    case "5":
                        return;
                    //default
                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            }
        }
        private static void PrintMenu()
        {
            //Creating a menu for user selection
            Console.WriteLine();
            Console.WriteLine("Select an option.");
            Console.WriteLine("1. Convert the restaurant profile table from SQL to JSON");
            Console.WriteLine("2. Showcase Our 5 Star Rating System");
            Console.WriteLine("3. Showcase Our Animated Bar Graph Review System");
            //Console.WriteLine("4. Play A Card Game");
            Console.WriteLine("5. Exit");
        }

        private static void SetTimer()
        {

            myAnimationTimer = new System.Timers.Timer(50);

            myAnimationTimer.Elapsed += OnTimedEvent;

            myAnimationTimer.AutoReset = true;

            myAnimationTimer.Enabled = true;
        }




        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Setting the bar graph colors
            var myBackgroundColor = ConsoleColor.White;
            var myBarGraphColor = ConsoleColor.Red;
            var consolecolor = ConsoleColor.Black;

            myTimerCount++;

            int rating;
            Random myRandomNumber = new Random();

            rating = myRandomNumber.Next(0, 100);

            Console.BackgroundColor = myBarGraphColor;


            for (int i = 0; i <= rating; i++)
            {

                Console.Write(" ");
            }


            int myTotalNumber = 10;


            Console.BackgroundColor = myBackgroundColor;

            for (int ii = rating; ii <= myTotalNumber; ii++)
            {

                Console.Write(" ");
            }

            Console.CursorLeft = 0;


            if (myTimerCount == 50)
            {
                //Stop Timer
                myAnimationTimer.Stop();



                for (int x = 0; x < 1; x++)
                {
                    Console.WriteLine("");
                }
                Console.BackgroundColor = consolecolor;

                Console.CursorVisible = true;

            }
        }
    }
}
