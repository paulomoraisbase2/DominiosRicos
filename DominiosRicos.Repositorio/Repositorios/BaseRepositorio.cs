using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Repositorio.Contexto;
using DominiosRicos.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DominiosRicos.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : Entity
    {
        protected readonly DominiosRicosContexto DominiosRicosContexto;
        protected readonly AuthenticatedUser _user;
        private List<EntityEntry> entriesAdded;

        public BaseRepositorio(DominiosRicosContexto DominiosRicosContexto, AuthenticatedUser user)
        {
            DominiosRicosContexto = DominiosRicosContexto;
            _user = user;
        }

        public void Add(TEntity entity)
        {
            DominiosRicosContexto.Set<TEntity>().Add(entity).State = EntityState.Added;
        }

        public void Add(IEnumerable<TEntity> entity)
        {
            foreach (var item in entity)
            {
                Add(item);
            }
        }

        public void DeleteAllOnSubmit(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                DominiosRicosContexto.Set<TEntity>().Attach(item);
                DominiosRicosContexto.Set<TEntity>().Remove(item);
            }
        }

        public void Update(TEntity entity)
        {
            DominiosRicosContexto.Set<TEntity>().Update(entity).State = EntityState.Modified;
        }

        public TEntity GetId(Guid Id)
        {
            return DominiosRicosContexto.Set<TEntity>().AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        public async Task<TEntity> GetIdAsync(Guid Id)
        {
            return await DominiosRicosContexto.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DominiosRicosContexto.Set<TEntity>().ToList();
        }

        public void Delete(TEntity entity)
        {
            DominiosRicosContexto.Set<TEntity>().Remove(entity).State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = DominiosRicosContexto.Set<TEntity>().Where(predicate);

            foreach (var entity in entities)
            {
                DominiosRicosContexto.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Dispose()
        {
            DominiosRicosContexto.Dispose();
        }

        public IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DominiosRicosContexto.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> Including(string includeProperties)
        {
            IQueryable<TEntity> query = DominiosRicosContexto.Set<TEntity>();
            query = query.Include(includeProperties);
            return query.AsEnumerable();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return DominiosRicosContexto.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DominiosRicosContexto.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return DominiosRicosContexto.Set<TEntity>().Where(predicate);
        }

        public void Commit()
        {
            //DominiosRicosContexto.SaveChanges();

            //List<EntityEntry> entriesAdded;
            // Detecta as alterações existentes na instância corrente do DbContext.
            DominiosRicosContexto.ChangeTracker.DetectChanges();
            // Identifica as entidades que devem gerar registros em log.
            var entries = DetectEntries().ToList();
            entriesAdded = DetectEntriesAdded().ToList();
            // Cria lista para armazenamento temporário dos registros em log.
            List<Auditoria> logs = new List<Auditoria>();
            // Varre as entidades que devem gerar registros em log.
            foreach (var entry in entries)
            {
                GetLog(entry);
            }
            foreach (var entry in entriesAdded)
            {
                GetLog(entry);
            }
            foreach (var item in logs)
            {
                DominiosRicosContexto.Entry(item).State = EntityState.Added;
            }

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    DominiosRicosContexto.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        if (databaseValues == null)
                        {
                            entry.CurrentValues.SetValues(proposedValues);
                            entry.OriginalValues.SetValues(proposedValues);

                            entry.State = EntityState.Added;
                            continue;
                        }
                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            proposedValues[property] = proposedValue;
                        }
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }
            }
        }

        /// <summary>
        /// Identifica quais entidades devem ser gerar registros de log.
        /// </summary>
        private IEnumerable<EntityEntry> DetectEntries()
        {
            return DominiosRicosContexto.ChangeTracker.Entries().Where(e => (e.State == EntityState.Modified ||
                                                        e.State == EntityState.Deleted) &&
                                                        e.Entity.GetType() != typeof(Auditoria));
        }

        private IEnumerable<EntityEntry> DetectEntriesAdded()
        {
            return DominiosRicosContexto.ChangeTracker.Entries().Where(e =>
                                                        e.State == EntityState.Added &&
                                                        e.Entity.GetType() != typeof(Auditoria));
        }

        /// <summary>
        /// Cria os registros de log.
        /// </summary>
        private void GetLog(EntityEntry entry)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Unchanged)
            {
                GetInsertLog(entry);
            }
            else if (entry.State == EntityState.Modified)
            {
                GetUpdateLog(entry);
            }
            else if (entry.State == EntityState.Deleted)
            {
                GetDeleteLog(entry);
            }
        }

        private void GetInsertLog(EntityEntry entry)
        {
            Usuario usuario = !string.IsNullOrEmpty(DominiosRicosContexto.Schema) ? GetUser : (Usuario)entriesAdded.FirstOrDefault(u => u.Entity.GetType() == typeof(Usuario)).Entity;
            Auditoria.CreateInsertLog(entry, usuario);
        }

        private void GetDeleteLog(EntityEntry entry)
        {
            Auditoria.CreateDeleteLog(entry, GetUser);
        }

        private void GetUpdateLog(EntityEntry entry)
        {
            var entryValue = entry.GetDatabaseValues();
            Dictionary<string, object> Alteracoes = new Dictionary<string, object>();
            foreach (var propriedade in entry.Properties)
            {
                if (!propriedade.Metadata.Name.ToLower().Contains("id"))
                {
                    var changedValue = propriedade.OriginalValue;
                    var originalValue = new object();
                    if (entryValue != null)
                        originalValue = entryValue.GetValue<object>(propriedade.Metadata.Name);

                    if (!((object)originalValue ?? "").Equals((object)changedValue ?? ""))
                    {
                        Alteracoes.Add(propriedade.Metadata.Name, changedValue);
                    }
                }
            }
            if (Alteracoes.Count() == 0) return;

            Auditoria.CreateUpdateLog(entry, Alteracoes, GetUser);
        }

        public Usuario GetUser => DominiosRicosContexto.Set<Usuario>().FirstOrDefault(u => u.Id == _user.UsuarioId);

        public Usuario Usuario(Email email) => DominiosRicosContexto.Set<Usuario>().FirstOrDefault(u => u.Email.Endereco == email.Endereco);

        public bool Exists(Guid Id)
        {
            return DominiosRicosContexto.Set<TEntity>().Find(Id) != default;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DominiosRicosContexto.Set<TEntity>().Any(predicate);
        }

        //Guid IBaseRepositorio<TEntity>.GetClinica => DominiosRicosContexto.Usuarios.FirstOrDefault(u => u.Id == _user.UsuarioId).ClinicaId;
    }
}