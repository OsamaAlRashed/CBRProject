using CBRProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRProject.Helpers
{
    public static class ValidateInputs
    {
        public static string ValidateName(string name)
        {
            return name;
        }

        public static int ValidateOrderCount(string count)
        {
            return Int32.TryParse(count, out int result) && result > 0 ? result : -1;
        }

        public static DayOfWeek? ValidateOrderDay(string day)
        {
            var formatDay = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(day.ToLower());
            return Enum.TryParse(formatDay, out DayOfWeek result) ? result : null;
        }

        public static int ValidateOrderTime(string time)
        {
            return Int32.TryParse(time, out int result) && result >= 0 && result <= 23 ? result : -1;
        }

        public static WeatherForecast? ValidateWeatherForecast(string weather)
        {
            var formatWeather = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(weather.ToLower());
            return Enum.TryParse(weather, out WeatherForecast result) ? result : null;
        }

        public static int ValidateLenghtOfWay(string lenOfWay)
        {
            return Int32.TryParse(lenOfWay, out int result) && result > 0 ? result : -1;
        }

        public static VehicleTypes? ValidateVehicleType(string vehicle)
        {
            var formatDay = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(vehicle.ToLower());
            return Enum.TryParse(formatDay, out VehicleTypes result) ? result : null;
        }

    }
}
