using System.Linq;
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
            Dictionary <string,List<Country>> countries = reader.ReadAllCountries();  
            
            foreach ( string region in countries.Keys)
                Console.WriteLine(region);                

            Console.Write("Which of the above regions do you want?");
            string chosenRegion = Console.ReadLine();

            if(countries.ContainsKey(chosenRegion)){
                foreach(Country country in countries[chosenRegion].Take(10))
                    Console.WriteLine(country.Name);
            }else{
                    Console.WriteLine("Region do not exists!");
            }
        }
    }
}
