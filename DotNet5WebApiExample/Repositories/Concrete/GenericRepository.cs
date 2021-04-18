using DotNet5WebApiExample.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5WebApiExample.Repositories.Concrete
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity>
    where Tentity : class
    {
        public GenericRepository() {}
        public void Create(Tentity entity)
        {
            using var db = new WebApiContext();
            db.Set<Tentity>().Add(entity);
            db.SaveChanges();
        }
        public void Delete(Tentity entity)
        {
            using var db = new WebApiContext();
            db.Set<Tentity>().Remove(entity);
                db.SaveChanges();
            
        }

        public List<Tentity> GetAll()
        {
            using var db = new WebApiContext();
            return db.Set<Tentity>().ToList();
        }

        public Tentity GetById(int id)
        {
            using var db = new WebApiContext();
            return db.Set<Tentity>().Find(id);
        }

        public void Update(Tentity entity)
        {
            using var db = new WebApiContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
