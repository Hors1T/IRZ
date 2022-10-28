using IRZ.Models;
using System;
using System.Threading.Tasks;

namespace IRZ.StackexchangeWork
{
    public interface IStackexchage
    {
        public void Work(Post post);
        public DateTime ConvertData(long unixTime);
    }
}
