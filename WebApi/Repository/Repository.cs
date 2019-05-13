using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.IRepository;
using WebApi.Models;

namespace WebApi.Repository
{
    public class Repository<T> : IGMTRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext context;
        private readonly DbSet<T> entities;
        public Repository(DatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public T Add(T t)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string id)
        {
            return entities.Any(e => e.Id == id);
        }

        public bool IsExists(List<T> ts)
        {
            foreach (var t in ts)
            {
                if (!IsExist(t.Id))
                {
                    return false;
                }
            }
            return true;
        }

        public ActionResult Put(T t)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        bool IGMTRepository<T>.Delete(List<T> ts)
        {
            if (!IsExists(ts))
            {
                return false;
            }
            foreach (var t in ts)
            {
                t.ModifiedDate = DateTime.Now;
                context.Entry(t).State = EntityState.Modified;
            }
            return true;
        }
    }
}
