using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Interfaces;
using Models;
using System.Collections.Specialized;
using Json;

/// <summary>
/// This class will manage the retrieval of Hacker News using the supplied API
/// it will cache the hih-level and allow drill-downs and searches as needed
/// CEB 6/3/2017 Nextech Code Assessment
/// </summary>
namespace Repository
{
    public class NewsRepository : INews
    {
        private static List<News> bigNewsList = new List<News>();
        //private static List<BestStories> bigNewsTopStories = new List<BestStories>();

        static NewsRepository()
        {
            const string url = "https://hacker-news.firebaseio.com/v0/item/{0}.json?print=pretty";
        //"https://hacker-news.firebaseio.com/v0/beststories.json?print=pretty";
            using (var client = new System.Net.Http.HttpClient())
                {
                client.BaseAddress = new Uri(String.Format(url, 121003));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add
                    (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(client.BaseAddress).Result;
                    var data = response.Content.ReadAsStringAsync().Result;

                //var b =
                ////  bigNewsTopStories = 
                //JsonConvert.DeserializeObject<List<BestStories>>(data);

                bigNewsList = JsonConvert.DeserializeObject<List<News>>($"[ {data} ]");

                NewsDTO newsDTO = new NewsDTO();
                newsDTO.news = bigNewsList;
                List<News> newBigList = bigNewsList;

                foreach (var i in newBigList)
                {
                    
                    foreach (var k in i.Kids)
                    { 
                        response = client.GetAsync(String.Format(url, k.ToString())).Result;
                        data = response.Content.ReadAsStringAsync().Result;
                        var x = JsonConvert.DeserializeObject<NewsBase>(data);

                        
                         i.kidsDTO = new KidsDTO(x);
                    }
                }
//                newsDTO.news = bigNewsList;
            }
        }
   
        public int Add (News item)
        {
            bigNewsList.Add(item);
            return item.Id;
        }
        public IEnumerable<News> GetAll()
        {
            return bigNewsList;
        }

        public News Get(int id)
        {
            News newNews = bigNewsList[id];
            return newNews;

        }
        public void Update(int id, News newsObj)
        {
            bigNewsList.Add(newsObj);
        }
        public void Remove(int id)
        {
            try
            {
                News thisObj = bigNewsList[id];
                bigNewsList.Remove(thisObj);
            }
            catch(Exception excp)
            {
                throw new ApplicationException(excp.Message);
            }

        }
        public News Find(int id)
        {
            News newObj = bigNewsList[id];
            return newObj;
        }

        public List<News> Search(string text)
        {
            List<News> newList = new List<News>();
            foreach(News n in bigNewsList)
            {
                if (n.Text.Contains(text))
                {
                    newList.Add(n);
                }
            }
            return newList;
        }
    }
}
