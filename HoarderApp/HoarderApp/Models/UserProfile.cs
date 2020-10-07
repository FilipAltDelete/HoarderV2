using System;
using Newtonsoft.Json;
namespace HoarderApp.Models
{
    public class UserProfile
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("accountDetailsId")]
        public int AccountDetailsId { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }

        

    }
}
