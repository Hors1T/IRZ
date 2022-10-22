using System;

namespace IRZ.StackexchangeWork
{
    public interface IStackexchage
    {
        public void Work(DateTime fromdate, DateTime todate, string tagged);
    }
}
