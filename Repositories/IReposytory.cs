using IRZ.Models;
using System;
using System.Collections.Generic;

namespace IRZ.Repositories
{
    public interface IRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> Get();
        public TDbModel Create(TDbModel model);
        public void Delete();
    }
}
