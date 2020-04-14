using System.Collections.Generic;
using System.Security.Cryptography;
using System;

namespace CountryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\NGE Impact\Beginning_C#_Collections\src\Country_C#_Collections\InputFile\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);
            var countries = reader.ReadAllCountries();
                        
            var input = Console.ReadLine();
            input = input.ToUpper();
                        
            foreach ( var country in countries.Keys)
            {
                if (country.Equals(input)){
                    Console.WriteLine($"{country} --- {countries[country].Name}");
                }
            }

        }
    }
}
