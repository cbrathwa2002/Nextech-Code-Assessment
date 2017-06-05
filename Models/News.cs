using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>



namespace Models
{
    public class News
    {
        public string Author { get; set; }
        public int id { get; set; }
        public int Descendants { get; set; }
        public int[] kids { get; set; }
        public int Score { get; set; }
        public int Parent { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Url {get;set;}
    }
}


  //"title" : "Ask HN: The Arc Effect",
  //"type" : "story",
  //"url" : ""