using IRZ.DataBase;
using IRZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRZ.Repositories
{
    public class Repository<TDbModel> : IRepository<TDbModel> where TDbModel : BaseModel
    {
        private DataContext Context { get; set; }
        public Repository(DataContext context)
        {
            Context = context;
        }

        public TDbModel Create(TDbModel model)
        {
            Context.Set<TDbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(x => x.Id == id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }

        public TDbModel Get(Guid id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(x => x.Id == id);
        }

        TDbModel IRepository<TDbModel>.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        TDbModel IRepository<TDbModel>.Create(TDbModel model)
        {
            throw new NotImplementedException();
        }

        void IRepository<TDbModel>.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
