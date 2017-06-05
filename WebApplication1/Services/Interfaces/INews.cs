using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
/// <summary>
/// INews interface class CEB 6/3/2017 Nextech Code Assessment
/// </summary>
namespace Interfaces
{
    public interface INews
    {
        int Add(News item);
        IEnumerable<News> GetAll();
        News Get(int id); 
        void Update(int id, News item);
        void Remove(int id);
        News Find(int id);
        List<News> Search(string text);
    
    }
}

