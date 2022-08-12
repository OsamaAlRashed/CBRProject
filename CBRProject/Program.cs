using CBRProject.Enums;
using CBRProject.Helpers;
using CBRProject.SimilarityFunctions;

namespace CBRProject
{
    class Program
    {


        static Order newOrder = new Order();
        static void Main(string[] args)
        {
            List<Order> orders = IOHelper.ReadCsvFile<Order>();

            var validateInputs = EnterQuery();
            if (!validateInputs)
            {
                return;
            }

            SimilarityFunction similarity = new SimilarityFunction();

            var resultList = similarity.GetSimilarity(orders, newOrder);

            int expectedTime = GetAverage(resultList.Take(3).Select(x => x.Item2.TimeCost).ToList());

            IOHelper.Print("The expected Time:");
            Console.WriteLine(expectedTime);

            IOHelper.Print("Revise this result:");
            IOHelper.Print("Enter 1 to accept or 0 to reject:");
            int decision = Int32.Parse(IOHelper.Read());
            if (decision == 0)
            {
                IOHelper.Print("Enter the real value:");
                decision = Int32.Parse(IOHelper.Read());
            }
            else
            {
                decision = expectedTime;
            }

            IOHelper.Print("Do you retain this result?");
            IOHelper.Print("Enter 1 to accept or 0 to reject:");
            int dec2 = Int32.Parse(IOHelper.Read());

            if(dec2 == 0)
            {
                IOHelper.Print("Finish.");
            }
            else
            {
                newOrder.TimeCost = decision;
                IOHelper.InsertRecordToCsvFile(newOrder);
                IOHelper.Print("The new Orded Added to dataset successfully.");
            }
            return;
        }

        static int GetAverage(List<int> times)
        {
            double avg = 0; 
            foreach (int time in times)
            {
                avg += time;
            }
            return (int)(avg / times.Count);
        }

        static bool EnterQuery()
        {
            string input;
            IOHelper.Print("Enter your query:", ConsoleColor.Green);

            IOHelper.Print("Enter Customer Name:");
            input = IOHelper.Read();
            newOrder.CustomerName = ValidateInputs.ValidateName(input);


            IOHelper.Print("Enter Order Count:");
            IOHelper.Print("1 -> 10");
            input = IOHelper.Read();
            if (ValidateInputs.ValidateOrderCount(input) == -1)
            {
                IOHelper.Print("Makesure from Order Count!", ConsoleColor.Red);
                return false;
            }
            else
            {
                newOrder.OrderCount = ValidateInputs.ValidateOrderCount(input);
            }

            IOHelper.Print("Enter Order Day:");
            IOHelper.Print("Sunday -> 0 , ..... , Saturday -> 6");
            input = IOHelper.Read();
            if (ValidateInputs.ValidateOrderDay(input) is null)
            {
                IOHelper.Print("Makesure from Order Day!", ConsoleColor.Red);
                return false;
            }
            else
            {
                newOrder.OrderDay = (DayOfWeek)ValidateInputs.ValidateOrderDay(input);
            }

            IOHelper.Print("Enter Order Time:");
            IOHelper.Print("10 -> 24");
            input = IOHelper.Read();
            if (ValidateInputs.ValidateOrderTime(input) == -1)
            {
                IOHelper.Print("Makesure from Order Time!", ConsoleColor.Red);
                return false;
            }
            else
            {
                newOrder.OrderTime = ValidateInputs.ValidateOrderTime(input);
            }

            IOHelper.Print("Enter WeatherForecast:");
            IOHelper.Print("Sunny -> 0 , Raining -> 1 , Snowy -> 2");
            input = IOHelper.Read();
            if (ValidateInputs.ValidateWeatherForecast(input) is null)
            {
                IOHelper.Print("Makesure from WeatherForecast!", ConsoleColor.Red);
                return false;
            }
            else
            {
                newOrder.WeatherForcast = (WeatherForecast)ValidateInputs.ValidateWeatherForecast(input);
            }

            IOHelper.Print("Enter length of way:");
            input = IOHelper.Read();
            if (ValidateInputs.ValidateLenghtOfWay(input) == -1)
            {
                IOHelper.Print("Makesure from length of way!", ConsoleColor.Red);
                return false;
            }
            else
            {
                newOrder.LengthOfWay = ValidateInputs.ValidateLenghtOfWay(input);
            }

            IOHelper.Print("Enter vehicle Type:");
            IOHelper.Print("Bike -> 0 , Electric Bike -> 1");
            input = IOHelper.Read();
            if (ValidateInputs.ValidateVehicleType(input) is null)
            {
                IOHelper.Print("Makesure from vehicle Type!", ConsoleColor.Red);
                return false;
            }
            else
            {
                newOrder.VehicleType = (VehicleTypes)ValidateInputs.ValidateVehicleType(input);
            }
            return true;
        }
    }
}
