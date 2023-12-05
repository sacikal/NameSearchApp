using NameSearchApp.Domain;

namespace NameSearchApp.Services
{
    public interface ISearchService
    {
        List<Person> Search(string term);
    }
}
