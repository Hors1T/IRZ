using System;
using System.Threading.Tasks;

namespace IRZ.StackexchangeWork
{
    public interface IStackexchage
    {
        public Task Work(DateTime fromdate, DateTime todate, string tagged);
    }
}
