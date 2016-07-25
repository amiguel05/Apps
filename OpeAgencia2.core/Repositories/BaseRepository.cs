using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperacionesAgencia.Business.Engine.Contracts;
using OperacionesAgencia.Infrastructure.Data.Context;
using OpeAgencia2.Core.Base;
using System.Linq.Expressions;
using System.Data.Entity;

namespace OpeAgencia2.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity: class, IEntity, new()
    {
        // Manuel A. Hernández. 14-01-2014
        /// <summary>
        /// Repositorio principal. Aquí se encuentran las operaciones básicas y coincidentes entre las entidades del modelo.
        /// </summary>
        
        #region Miembros
        private readonly UnitOfWork _unit;
        #endregion 

        public BaseRepository(IUnitOfWork _context)
        {
            _unit = (UnitOfWork)_context;
        }

        /// <summary>
        /// Permite obtener todos los registros de una entidad. Eq: SELECT * FROM TABLA
        /// </summary>
        /// <returns>El resultado de la consulta.</returns>
        /// 
        public ICollection<TEntity> GetAll()
        {
            var result = _unit.Set<TEntity>().ToList();

            return result;
        }

        public ICollection<TEntity> GetAll(int page, int pageSize)
        {
            var result = _unit.Set<TEntity>().Skip(page).Take(pageSize).ToList();

            return result;
        }

        /// <summary>
        /// Obtiene todos los registros e incluye otros campos de otras entidades.
        /// </summary>
        /// <param name="includes">Entidades que saldrán.</param>
        /// <returns></returns>
        public ICollection<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            ICollection<TEntity> result = null;
            IQueryable<TEntity> query = _unit.Set<TEntity>();

            if (includes != null)
            {
                var members = includes.Select(e => e.Body).OfType<MemberExpression>().Select(e => e.Member).ToList();
                
                members.ForEach(x =>
                {
                    query = _unit.Set<TEntity>().Include(x.Name);

                });
                result = query.ToList();
                return result;
            }

            result = query.ToList();

            return result;
        }


        /// <summary>
        /// Permite obtener un registro en base a una condición por su PK. Eq: SELECT * FROM TABLA WHERE PK = VALOR
        /// </summary>
        /// <param name="id">Valor que se pasará como argumento a la consulta.</param>
        /// <returns></returns>
        public TEntity Get(int id)
        {
            var result = _unit.Set<TEntity>().FirstOrDefault(e => e.EntityId == id);

            return result;
        }

        /// <summary>
        /// Permite crear un registro nuevo. Eq: INSERT INTO TABLA VALUES(valores...)
        /// </summary>
        /// <param name="entity">Entidad con los valores correspondientes a añadir.</param>
        public TEntity Create(TEntity entity)
        {
            _unit.Set<TEntity>().Add(entity);
            return entity;
        }

        /// <summary>
        /// Permite actualizar un registro existente. Eq: UPDATE TABLA SET [VALUES..] WHERE CAMPO = ARG
        /// </summary>
        /// <param name="entity">Entidad existente con los valores correspondientes a actualizar.</param>
        public void Update(TEntity entity)
        {
            if (entity.EntityId != default(int))
                _unit.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Permite eliminar un registro existente. Eq: DELETE FROM TABLA WHERE CAMPO = ARG
        /// </summary>
        /// <param name="entity">Entidad existente que se quiere eliminar.</param>
        public void Delete(TEntity entity)
        {
            if (entity.EntityId != default(int))
                _unit.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        /// <summary>
        /// Permite buscar registros en base a una condición. Eq: SELECT * FROM TABLA WHERE CAMPO = ARG
        /// </summary>
        /// <param name="predicate">Expresión que se pasará como argumento a la consulta.</param>
        /// <returns>Resultado de la consulta</returns>
        public ICollection<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _unit.Set<TEntity>().Where(predicate).ToList();

            return result;
        }

        /// <summary>
        /// Permite buscar registros en base a una condición. Permite hacer JOIN entre tablas.
        /// Eq: SELECT * FROM TABLA JOIN TABLA2 ON [CONDICION..] WHERE CAMPO = ARG
        /// </summary>
        /// <param name="predicate">Expresión que servirá como argumento para la consulta.</param>
        /// <param name="properties">Tablas que se van a incluir en el Join</param>
        /// <returns>Resultado de la consulta.</returns>
        public ICollection<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            var members = properties.Select(e => e.Body).OfType<MemberExpression>().Select(e => e.Member).ToList();
            IQueryable<TEntity> query = _unit.Set<TEntity>();

            members.ForEach(e =>
            {
                query = query.Include(e.Name);
            });
            var result = query.Where(predicate).ToList();

            return result;
        }

        /// <summary>
        /// Permite ejecutar consultas SQL Limpias (RAW_SQL)
        /// </summary>
        /// <param name="query">Query o consulta a realizar.</param>
        /// <param name="parameters">Argumentos para la consulta</param>
        /// <returns>Lista de valores en base al resultado</returns>
        public ICollection<TEntity> ExecSql(string query, params object[] parameters)
        {
            var result = _unit.Set<TEntity>().SqlQuery(query, parameters).ToList();

            return result;
        }

    }
}
