using Newtonsoft.Json;

namespace CatApp.Models;
    public class Cat
    {
    [JsonProperty("url")]
    public string CatImageUrl { get; set; }
    }
