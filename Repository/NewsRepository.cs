using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;
using System.Collections.Specialized;
/// <summary>
/// 
/// </summary>
namespace Repository
{
    public class NewsRepository : INews
    {
        private static List<News> bigNewsList = new List<News>();
        private static bool _alreadyLoaded = false;

        static NewsRepository()
        {
                const string url = "https://hacker-news.firebaseio.com/v0/item/121003.json?print=pretty";

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add
                    (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(url).Result;
                    var data = response.Content.ReadAsStringAsync().Result;
                    //result = JsonConvert.DeserializeObject<List<Rideplicity_reference>>(data);
                }
                //return result;
            //}
            //lock()
            //{
            _alreadyLoaded = true;

            //}

        }

        public int Add (News _newObj)
        {
            News newObj = new News();
            return 1;
        }

        //public static void loadNews()
        //{

        //}

     
        public IEnumerable<News> GetAll()
        {
            return bigNewsList;

        }

        public News Get(int id)
        {
            News newNews = null;
            return newNews;

        }
        public void Update(int id, News newsObj)
        {
            //bigNewsList.Remove(newsObj.id);
            //return newsObj;
        }
        public void Remove (int id)
        {
          //  bigNewsList.Remove(id);

        }
        public News Find (int id)
        {
            News newObj = new Models.News();
            return newObj;
        }
    }
}
