using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// News classes CEB 6/3/2017 Nextech Code Assessment
/// make it a DTO so we only send back the data the client needs, no more, no less
/// </summary>

namespace Services.News
{
    using Newtonsoft.Json;
  
    public class NewsDTO
    {
        public String Author { get; set; }
        public String Title { get; set; }
    } 
}