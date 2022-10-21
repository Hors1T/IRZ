using IRZ.Models;
using System;
using System.Collections.Generic;

namespace IRZ.Repositories
{
    public interface IRepository<TDbModel> where TDbModel : BaseModel
    {
        public TDbModel Get(Guid id);
        public TDbModel Create(TDbModel model);
        public void Delete(Guid id);
    }
}
