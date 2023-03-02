using Abstraction;
using ApiRest.Abstraction;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DbContext<T> : IDbContext<T> where T: class,IEntity
    {
        //Objecto que permite implementar Entity framework
        DbSet<T> _items;
        ApiDbContext _ctx;

        //Obtenemos nuestro proveedor de datos configurado
        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            //Setear nuestra lista obtenido del objecto
            _items = ctx.Set<T>();
        }

        public void Delete(int id)
        {
            _items.Remove(_items.Where(i => i.Id.Equals(id)).FirstOrDefault());
            //Se grabe los cambios
            _ctx.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _items.Add(entity);
            //Se grabe los cambios
            _ctx.SaveChanges();
            return entity;
        }
    }
}
