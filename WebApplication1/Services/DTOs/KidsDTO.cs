using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// News, NewsBase and KidsDTO classes CEB 6/3/2017 Nextech Code Assessment
/// </summary>

namespace Models.Kids
{
    using Newtonsoft.Json;
   
    public class KidsDTO
    {
        public List<NewsBase> subNews = new List<NewsBase>();

        public KidsDTO(NewsBase data)
        {
            subNews.Add(data);
        }
    }
  
    //public class KidsDTO : NewsBase
    //{
    //    [JsonProperty("descendants")]
    //    public string Descendants { get; set; }
    //    [JsonProperty("title")]
    //    public string Title { get; set; }
    //    [JsonProperty("url")]
    //    public string Url { get; set; }
    //    public KidsDTO kidsDTO { get; set; }
    //}
}