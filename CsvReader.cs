using System.Collections.Generic;
using System.IO;
using System;
namespace CountryCollection
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header Line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvFile(csvLine));
                }

            }
            return countries;
        }

        public void RemoveCountries(List <Country> countries){
            countries.RemoveAll(x=>x.Name.Contains(","));
        }

        public Country ReadCountryFromCsvFile(string csvLine)
        {
            String[] parts = csvLine.Split(new char[] { ',' });
            string name;
            string code;
            string region;
            string popText;

            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0]+","+parts[1];
                    name = name.Replace("/",null).Trim(); 
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;

                default:
                    throw new Exception($"Can't parse country from csvline:{csvLine}");
            }
            
            int.TryParse(popText,out int population);


            return new Country(name, code, region, population);
        }
    }

}