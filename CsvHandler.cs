
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AddressBookSystemIO
{
    /// <summary>
    /// UC-14 CSV Handler
    /// </summary>
    public class CsvHandler
    {
        public static bool InvariantCulture { get; private set; }

        public void ImplementCSV()
        {
            string importFilePath = @"C:\Users\HP\Desktop\fellowShip\AddressBookSystemIO\CsvFile.csv";
            string exportFilePath = @"C:\Users\HP\Desktop\fellowShip\AddressBookSystemIO\Export.csv";
            //Reading CSV File

            using (var reader = new StreamReader(importFilePath))
            using (var CSV = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = CSV.GetRecords<AddressData>().ToList();

                Console.WriteLine("Read Data Successfully From Address Book");
                foreach (AddressData record in records)
                {
                    Console.WriteLine(record.FirstName);
                    Console.WriteLine(record.LastName);
                    Console.WriteLine(record.Address);
                    Console.WriteLine(record.City);
                    Console.WriteLine(record.State);
                    Console.WriteLine(record.Zip);
                    Console.WriteLine(record.Phone);
                    Console.WriteLine(record.Email);
                }

                //Writing into CSV
                Console.WriteLine("Writing to The file");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvexport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvexport.WriteRecords(records);
                }
            }

        }
    }
}
