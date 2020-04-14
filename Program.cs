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
            List<Country> countries = reader.ReadAllCountries();
            
            Country Lilliput = new Country("Lilliput","LiL","Somewhere",2_000_000);
            
            //Find a specific index dynamicly depending on the filter
            int lilliputIndex = countries.FindIndex(x=>x.Population<2_000_000);
            
            //Insert item into a list in a specific index
            countries.Insert(lilliputIndex,Lilliput);
            
            //Remove item from a list
            countries.RemoveAt(lilliputIndex);
            
            foreach ( Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");                
            }

             Console.WriteLine($"{countries.Count} Countries");
        }
    }
}
