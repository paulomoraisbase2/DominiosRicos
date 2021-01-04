using DominiosRicos.Shared.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DominiosRicos.Dominio.Entidades
{
    public class Auditoria : Entity
    {
        private const string INSERT_ACTION = "Insert";
        private const string UPDATE_ACTION = "Update";
        private const string DELETE_ACTION = "Delete";

        public Auditoria() : base(default)
        {
        }

        public string Acao { get; private set; }
        public string NovoValor { get; private set; }
        public DateTime DataExecucao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid RegistroId { get; private set; }
        public string RegistroTabela { get; private set; }

        public Auditoria(

            string acao,
            string novoValor,
            Usuario usuario,
            Guid registroId,
            string registroTabela) : base(default)
        {
            Acao = acao;
            NovoValor = novoValor;
            DataExecucao = DateTime.Now;
            Usuario = usuario;
            RegistroId = registroId;
            RegistroTabela = registroTabela;
        }

        public static void CreateInsertLog(EntityEntry newEntity, Usuario usuario)
        {
            try
            {
                var primaryKey = newEntity.Metadata.FindPrimaryKey();
                var keys = primaryKey.Properties.ToDictionary(x => x.Name, x => x.PropertyInfo.GetValue(newEntity.Entity)).FirstOrDefault(f => f.Key == "Id");

                var log = new Auditoria(
                    acao: INSERT_ACTION,
                    novoValor: Serialize(newEntity.Entity),
                    usuario: usuario,
                    registroId: (Guid)keys.Value,
                    registroTabela: newEntity.Entity.GetType().ToString().Replace("DominiosRicos.Dominio.Entidades.", "")
                    );
                usuario.AddAuditoria(log);
            }
            catch
            {
            }
        }

        public static void CreateDeleteLog(EntityEntry delEntity, Usuario usuario)
        {
            try
            {
                var propertyValues = delEntity.GetDatabaseValues();
                Dictionary<string, object> deletado = new Dictionary<string, object>();
                foreach (var Propertie in propertyValues.Properties)
                {
                    deletado.Add(Propertie.Name, propertyValues.GetValue<object>(Propertie.Name));
                }
                var primaryKey = delEntity.Metadata.FindPrimaryKey();
                var keys = primaryKey.Properties.ToDictionary(x => x.Name, x => x.PropertyInfo.GetValue(delEntity.Entity)).FirstOrDefault(f => f.Key == "Id");

                Auditoria log = new Auditoria(

                    acao: DELETE_ACTION,
                    novoValor: Serialize(deletado),
                    //usuarioId: usuario.Id,
                    usuario: usuario,
                    registroTabela: propertyValues.EntityType.ToString().Replace("EntityType: ", ""),
                    registroId: (Guid)keys.Value
                );
                usuario.AddAuditoria(log);
            }
            catch
            {
            }
        }

        public static void CreateUpdateLog(EntityEntry Entity, object Alteracao, Usuario usuario)
        {
            try
            {
                var primaryKey = Entity.Metadata.FindPrimaryKey();
                var keys = primaryKey.Properties.ToDictionary(x => x.Name, x => x.PropertyInfo.GetValue(Entity.Entity)).FirstOrDefault(f => f.Key == "Id");

                Auditoria log = new Auditoria(
                acao: UPDATE_ACTION,
                novoValor: Serialize(Alteracao),
                //usuarioId: usuario.Id,
                usuario: usuario,
                registroTabela: Entity.Entity.GetType().ToString().Replace("DominiosRicos.Dominio.Entidades.", ""),
                registroId: Guid.Parse(keys.Value.ToString()));
                usuario.AddAuditoria(log);
            }
            catch
            {
            }
        }

        private static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}