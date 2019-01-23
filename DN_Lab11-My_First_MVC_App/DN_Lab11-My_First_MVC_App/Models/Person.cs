using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DN_Lab11_My_First_MVC_App.Models
{
    public class Person
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public static string[] ParseCSV(string filePath)
        {
             
            string setRoot = Environment.CurrentDirectory;
            string finalPath = Path.GetFullPath(Path.Combine(setRoot, filePath));
            string[] rawData = File.ReadAllLines(filePath);
            string[] properties = new string[rawData.Length];
            for (int i = 0; i < rawData.Length; i++)
            {
                properties = rawData[i].Split(',');
            }
            return properties;   
        }

        public static List<Person> AllPeople(string[] parsedCSV)
        {
            List<Person> allPeople = new List<Person>();
            for (int i = 0; i < parsedCSV.Length; i++)
            {
                allPeople.Add(new Person
                {
                    Year = Convert.ToInt32(parsedCSV[0]), 
                    Honor = parsedCSV[1], 
                    Name = parsedCSV[2], 
                    Country = parsedCSV[3], 
                    Birth_Year = (parsedCSV[4] == "") ? 0 : Convert.ToInt32(parsedCSV[4]),
                    DeathYear = (parsedCSV[5] == "") ? 0 : Convert.ToInt32(parsedCSV[5]),
                    Title = parsedCSV[6],
                    Category = parsedCSV[7],
                    Context = parsedCSV[8],
                });
            }
            return allPeople;
        }

        public static List<Person> FilteredPeople(List<Person> allPeople, int startYear, int endYear)
        {
            List<Person> filteredPeople = allPeople.Where(person => (person.Year >= startYear) && (person.Year <= endYear)).ToList();
            return filteredPeople;
        }

        public static List<Person> Search(int startYear, int endYear)
        {
            string _filePath = @"wwwroot\personOfTheYear.csv";
            string[] parsedCSV = ParseCSV(_filePath);
            List<Person> allPeople = AllPeople(parsedCSV);
            List<Person> filteredPeople = FilteredPeople(allPeople, startYear, endYear);
            return filteredPeople;
        }

    }
}
