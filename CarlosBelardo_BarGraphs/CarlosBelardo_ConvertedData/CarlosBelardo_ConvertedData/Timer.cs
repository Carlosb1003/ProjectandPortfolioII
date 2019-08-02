using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MySql.Data.MySqlClient;

namespace CarlosBelardo_ConvertedData
{
    class Timer
    {
        public static string cs = @"server=172.16.157.1;userid=debremoteuser;password=password;database=SampleRestaurantDatabase;port=8889";

        private static System.Timers.Timer myAnimationTimer;

        //Timer Counter       
        static int myTimerCount = 0;


       
        public static void Bar()
        {
            //Creating Timer
            SetTimer();
            
            Console.CursorVisible = false;

            Console.ReadLine();
        }



        //setting timer properties
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
                MySqlConnection conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT Restaurantprofiles.RestaurantName,Count(ReviewScore) From RestaurantReviews inner join RestaurantProfiles on RestaurantProfiles.id = RestaurantReviews.Restaurantid Where ReviewColor = 'GREEN' Group by RestaurantProfiles.ID Order By Rand() Limit 1; ";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    Program.RestaurantName = rdr["RestaurantName"].ToString();
                    string PosReview = rdr["COUNT(ReviewScore)"].ToString();
                    int review;
                    int.TryParse(PosReview, out review);
                    Console.WriteLine(Program.RestaurantName + " " + review);

                    if (review <= 30)
                    {
                        int myTimerCount = 0;

                        myBackgroundColor = ConsoleColor.White;
                        myBarGraphColor = ConsoleColor.Red;
                        consolecolor = ConsoleColor.Black;

                        myTimerCount++;
                        Console.BackgroundColor = myBarGraphColor;


                        rating = review;


                        for (int i = 0; i <= rating; i++)
                        {

                            Console.Write(" ");
                        }
                        int totalnumber = 100;
                        Console.BackgroundColor = myBackgroundColor;
                        for (int ii = rating; ii <= totalnumber; ii++)
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

                        myBackgroundColor = ConsoleColor.White;
                        myBarGraphColor = ConsoleColor.Yellow;
                        consolecolor = ConsoleColor.Black;
                        myTimerCount++;
                        Console.BackgroundColor = myBarGraphColor;


                        rating = review;


                        for (int i = 0; i <= rating; i++)
                        {

                            Console.Write(" ");
                        }
                        int totalnumber = 100;
                        Console.BackgroundColor = myBackgroundColor;
                        for (int ii = rating; ii <= totalnumber; ii++)
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

            

        }



    }
}
