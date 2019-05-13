using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.IRepository
{
    public interface IGMTRepository<T> where T : BaseEntity
    {

        IEnumerable<T> GetAll();

        T Get(string id);

        T Add(T t);

        Task Save();

        bool Delete(List<T> ts);

        ActionResult Put(T t);

        bool IsExist(string id);

        bool IsExists(List<T> ts);

    }
}
