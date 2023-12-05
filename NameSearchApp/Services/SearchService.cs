using NameSearchApp.Domain;
using Newtonsoft.Json;
using System;
using System.Xml.Linq;

namespace NameSearchApp.Services
{
    public class SearchService : ISearchService
    {
        private List<Person> _people;

        public SearchService(string filePath)
        {
            LoadData(filePath);
        }

        private void LoadData(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);

                    _people = JsonConvert.DeserializeObject<List<Person>>(jsonContent);
                }
            }

            catch(Exception ex)
            {
                // Handle exceptions, e.g., log or throw as needed
                Console.WriteLine($"Error loading data from file: {ex.Message}");
                _people = new List<Person>();
            }
        }

        public List<Person> Search(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                // If the search term is empty or consists only of white spaces, return an empty list
                return new List<Person>();
            }

            return _people.Where(p =>$"{p.FirstName} {p.LastName}".Equals(term, StringComparison.InvariantCultureIgnoreCase) ||
                                        p.FirstName.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                                        p.LastName.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                                        p.Email.Contains(term, StringComparison.InvariantCultureIgnoreCase))
                          .ToList();
        }
    }
}
