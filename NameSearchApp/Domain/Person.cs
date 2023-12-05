using Newtonsoft.Json;

namespace NameSearchApp.Domain
{
    public class Person
    {
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName  { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
