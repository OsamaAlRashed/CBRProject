using CBRProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRProject
{
    public class Order
    {
        public string CustomerName { get; set; }
        public int OrderCount { get; set; }
        public int LengthOfWay { get; set; }
        public int OrderTime { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public WeatherForecast WeatherForcast { get; set; }
        public DayOfWeek OrderDay { get; set; }
        public int TimeCost { get; set; }
    }
}
