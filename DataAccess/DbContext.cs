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
            // Verificar si la entidad ya existe en la base de datos
            T existingEntity = _items.FirstOrDefault(i => i.Id.Equals(entity.Id));

            if (existingEntity != null)
                //se actualiza la entidad existente con los valores de la entidad que se pasa como parámetro.
                _ctx.Entry(existingEntity).CurrentValues.SetValues(entity);
            else
                _items.Add(entity);

            // Guardar los cambios
            _ctx.SaveChanges();
            return entity;
        }
    }
}
