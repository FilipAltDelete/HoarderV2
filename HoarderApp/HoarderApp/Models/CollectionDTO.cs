using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace HoarderApp.Models
{
    public class CollectionDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("collectionName")]
        public string CollectionName { get; set; }
        [JsonProperty("isShared")]
        public bool IsShared { get; set; }
        [JsonProperty("userProfileId")]
        public int UserProfileId { get; set; }
    }

    public class Collection
    {
        public List<CollectionDTO> CollectionList { get; set; }
    }
}
