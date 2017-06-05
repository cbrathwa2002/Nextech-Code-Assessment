using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextechCodeAssessment;
using Interfaces;
using Models;
using Repository;
using Services.News;
using System.Timers;

namespace NextechCodeAssessment.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {

        private readonly NewsRepository _repo = new NewsRepository();
        // keep a local cache copy of data for quick access
        // assuming top news will not change every minute so set a timer to force a refresh every hour
        // make serializable so we can stream it off locally and reload with little effort, make a class out of it to do so
       // [Serializable]
        private static List<NewsDTO> newsDTO = new List<NewsDTO>();
        private object _lockMe = new object();

        // GET api/News
        [HttpGet]
        public IActionResult GetNews()
        {
            // block access until data is loaded

            lock (_lockMe) {
                if (newsDTO.Count() > 0)
                    return Ok(newsDTO.OrderBy(x => x.Author));

                var data = _repo.GetAll();
                if (data != null)
                {
                    foreach (var n in data)
                    {
                        newsDTO.Add(new NewsDTO
                        {
                            Author = n.Author,
                            Title = n.Title
                        });
                    }
                    return Ok(newsDTO.OrderBy(x => x.Author));
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // GET api/news/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _repo.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/News
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/News/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();

            //News thisObj = null;
            //_repo.Update(id, thisObj);
        }

        // DELETE api/News/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }

        public IActionResult Search(string text)
        {
            // the requirements did not specify what kind of search (just titles or data or comments)
            // this will handle the search of news' body and return the list of news items the contains that string  
            var data = _repo.Search(text);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
