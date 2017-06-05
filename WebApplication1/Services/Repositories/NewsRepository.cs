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

using Services.News;

/// <summary>
/// This class will manage the retrieval of Hacker News using the supplied API
/// it will cache the hih-level and allow drill-downs and searches as needed
/// CEB 6/3/2017 Nextech Code Assessment
/// this is a poor interface, I have to first access the top level then navigate through Collection of items to find Authors and Titles
/// costly client call for each piece of news
/// </summary>
namespace Repository
{
    public class NewsRepository : INews
    {
      
        private List<News> bigNewsList = new List<News>();
        private Int64[] bigNewsTopStories = new Int64[500];
        private Int64[] getBestStories()
        {
            const string url = "https://hacker-news.firebaseio.com/v0/beststories.json?print=pretty";
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
                (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(client.BaseAddress).Result;
                var data = response.Content.ReadAsStringAsync().Result;

                bigNewsTopStories = JsonConvert.DeserializeObject<Int64[]>(data);

            }
            return bigNewsTopStories;
        }

        private List<News> getNews()
        {
            const string url = "https://hacker-news.firebaseio.com/v0/item/{0}.json?print=pretty";
            foreach (var n in bigNewsTopStories)
            {
                using (var client = new System.Net.Http.HttpClient())
                {

                    client.BaseAddress = new Uri(String.Format(url, n));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add
                    (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(client.BaseAddress).Result;
                    var data = response.Content.ReadAsStringAsync().Result;

                    News thisNewsList = JsonConvert.DeserializeObject<News>(data);
                    bigNewsList.Add(thisNewsList);
               

                }
            }
            return bigNewsList;

        }
    
    
    public NewsRepository()
        {
            getBestStories();
            getNews();
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
