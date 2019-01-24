using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DN_Lab11_My_First_MVC_App.Models
{
    /// <summary>
    /// A class that is modeled after personOfTheYear.csv internally contains methods that can parse .csv file and will create a list of people. It also contains a method that allows user to search for people using the year that they were person of the year.
    /// </summary>
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

        /// <summary>
        /// Reads a file and returns an string[] of raw data where each index is a line of that file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>string[] rawData</returns>
        public static string[] ReadFile(string filePath)
        {
             
            string setRoot = Environment.CurrentDirectory;
            string finalPath = Path.GetFullPath(Path.Combine(setRoot, filePath));
            string[] rawData = File.ReadAllLines(filePath);
            
            return rawData;   
        }

        /// <summary>
        /// Receives raw data and parses it into a List with all people found within that file.
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns>Returns a list of all of people found within raw data.</returns>
        public static List<Person> AllPeople(string[] rawData)
        {

            string[] parsedCSV = new string[rawData.Length];
            List<Person> allPeople = new List<Person>();
            for (int i = 1; i < rawData.Length; i++)
            {
                parsedCSV = rawData[i].Split(',');
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
        
        /// <summary>
        /// Takes in a list of people and conducts a search within a startYear and endYear and returns a filtered list of people.
        /// </summary>
        /// <param name="allPeople"></param>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns>filtered list of people</returns>
        public static List<Person> FilteredPeople(List<Person> allPeople, int startYear, int endYear)
        {
            List<Person> filteredPeople = allPeople.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();
            return filteredPeople;
        }

        /// <summary>
        /// Master method of people class that combines ReadFile, AllPeople and FilteredPeople and returns a list of filtered people using inputs of startYear and endYear.
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns>Filtered list of people.</returns>
        public static List<Person> Search(int startYear, int endYear)
        {
            string _filePath = @"wwwroot\personOfTheYear.csv";
            string[] rawData = ReadFile(_filePath);
            List<Person> allPeople = AllPeople(rawData);
            List<Person> filteredPeople = FilteredPeople(allPeople, startYear, endYear);
            return filteredPeople;
        }

    }
}
