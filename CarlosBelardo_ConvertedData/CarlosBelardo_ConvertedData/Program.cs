using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace CarlosBelardo_ConvertedData
{
    class Program
    {
        //fields
        static string Id;
        static string RestaurantName;
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
                                    Console.WriteLine("File Located in "+fullPath);
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
                    //for future assignment
                    case "showcase our 5 star rating system":
                    case "2":
                        {

                        }
                        break;
                    //for future assignment
                    case "showcase our anumated bar graph review system":
                    case "3":
                        {

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
            //Console.WriteLine("2. Showcase Our 5 Star Rating System");
            //Console.WriteLine("3. Showcase Our Animated Bar Graph Review System");
            //Console.WriteLine("4. Play A Card Game");
            Console.WriteLine("5. Exit");
        }

       

    }
}
