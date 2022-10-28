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

        public void Delete()
        {
            var rows = from o in Context.Set<TDbModel>()
                       select o;
            foreach (var row in rows)
            {
                Context.Set<TDbModel>().Remove(row);
            }
            Context.SaveChanges();
        }

        public List<TDbModel> Get()
        {
            return Context.Set<TDbModel>().ToList();
        }

    }
}
