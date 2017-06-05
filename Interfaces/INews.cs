using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
/// <summary>
/// 
/// </summary>
namespace Interfaces
{
    public interface INews
    {
        int Add(News item);
        IEnumerable<News> GetAll();
        News Get(int id);
        //News GetById(News id);
        void Update(int id, News item);
        void Remove(int id);
        News Find(int id);
    }
}

