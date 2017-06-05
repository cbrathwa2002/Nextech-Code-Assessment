using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// News, NewsBase classes CEB 6/3/2017 Nextech Code Assessment
/// </summary>

namespace Models
{
    using Newtonsoft.Json;
 
    public class NewsBase
    {
        [JsonProperty("by")]
        public string Author { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("kids")]
        public int[] Kids { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("parent")]
        public int Parent { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class News : NewsBase
    {
        [JsonProperty("descendants")]
        public string Descendants { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    
    }
}