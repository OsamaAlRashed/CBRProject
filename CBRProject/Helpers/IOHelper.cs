using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRProject.Helpers
{
    public static class IOHelper
    {
        public static void Print(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static string Read()
        {
            return Console.ReadLine();
        }
        public static List<T> ReadCsvFile<T>()
        {
            List<T> list = new List<T>();
            try
            {
                using (var reader = new StreamReader($@"C:\Users\Osama Al-Rashed\source\repos\CBRProject\CBRProject\CsvFiles\data_set.csv", Encoding.Default))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CreateSpecificCulture("en-us")))
                {
                    list = csv.GetRecords<T>().ToList();
                }
            }
            catch
            {
            }
            return list;
        }
        public static void InsertRecordToCsvFile<T>(T newItem)
        {
            bool append = true;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.HasHeaderRecord = !append;
            using (var writer = new StreamWriter($@"C:\Users\Osama Al-Rashed\source\repos\CBRProject\CBRProject\CsvFiles\data_set.csv", append))
            {
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(new List<T>(1) { newItem });
                }
            }
        }
    }
}
