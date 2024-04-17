using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Reflection.Emit;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
       

            logger.LogInfo("Log initialized");

            
            var lines = File.ReadAllLines(csvPath);

           
            logger.LogInfo($"Lines: {lines[0]}");

            
            var parser = new TacoParser();

     
            var locations = lines.Select(parser.Parse).ToArray();

  
           
            ITrackable trackable = null;

            ITrackable trackable1 = null;
            
         

            double distance = 0;

            
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();

                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();

                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    double distanceChecker = corA.GetDistanceTo(corB);

                    if (distanceChecker > distance)
                    {
                        distance = distanceChecker;

                        trackable = locA;
                        trackable1 = locB;


                    }
                }
            }

            Console.WriteLine($" The two tacobells furthest from eachother are {trackable.Name} at coordinate {trackable.Location.Latitude} {trackable.Location.Longitude} " +
                $"and {trackable1.Name} at coordinate {trackable1.Location.Latitude}{trackable1.Location.Longitude}");

            // TODO: Once you have locA, create a new Coordinate object called `corA` with your locA's latitude and longitude.

            // SECOND FOR LOOP -
            // TODO: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
            // This allows you to pick a "destination" location for each "origin" location from the first loop. 
            // Naming suggestion for variable: `locB`

            // TODO: Once you have locB, create a new Coordinate object called `corB` with your locB's latitude and longitude.

            // TODO: Now, still being inside the scope of the second for loop, compare the two locations using `.GetDistanceTo()` method, which returns a double.
            // If the distance is greater than the currently saved distance, update the distance variable and the two `ITrackable` variables you set above.

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.



        }
    }
}
