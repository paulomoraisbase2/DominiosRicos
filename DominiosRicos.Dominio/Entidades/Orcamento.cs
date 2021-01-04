using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Entidades
{
    public class Orcamento : Entity
    {
        public Guid PacienteId { get; private set; }
        [JsonIgnore] public virtual Paciente Paciente { get; private set; }
        public string Tratamento { get; private set; }
        public virtual Periodo Periodo { get; private set; }
        public DateTime? Aprovado { get; private set; }
        public Status Status { get; private set; }
        public bool Rascunho { get; private set; }
        public string TipoDenticao { get; private set; }
        public Guid? DentistaId { get; private set; }
        [JsonIgnore] public virtual Dentista Dentista { get; private set; }
        public virtual ICollection<OrcamentoProcedimento> OrcamentoProcedimentos { get; set; }
        public virtual ICollection<OrcamentoComentario> OrcamentoComentarios { get; set; }
        public virtual ICollection<OrcamentoDentesRemovido> OrcamentoDentesRemovidos { get; set; }

        public Orcamento() : base(default)
        {
        }

        public Orcamento(Guid id,
            Guid pacienteId,
            string tratamento,
            Periodo periodo,
            DateTime? aprovado,
            Status status,
            Guid? dentistaId,
            string tipoDenticao,
            bool rascunho) : base(id)
        {
            PacienteId = pacienteId;
            Tratamento = tratamento;
            Periodo = periodo;
            Aprovado = aprovado;
            Status = status;
            DentistaId = dentistaId;
            TipoDenticao = tipoDenticao;
            Rascunho = rascunho;
            OrcamentoProcedimentos = new List<OrcamentoProcedimento>();
            OrcamentoComentarios = new List<OrcamentoComentario>();
            OrcamentoDentesRemovidos = new List<OrcamentoDentesRemovido>();
        }

        public void AddProcedimentos(OrcamentoProcedimento procedimento)
        {
            if (procedimento == null) return;
            OrcamentoProcedimentos.Add(procedimento);
        }

        public void AddComentarios(OrcamentoComentario comentario)
        {
            if (comentario == null) return;
            OrcamentoComentarios.Add(comentario);
        }

        public void AddDentesRemovidos(OrcamentoDentesRemovido denteRemovido)
        {
            if (denteRemovido == null) return;
            OrcamentoDentesRemovidos.Add(denteRemovido);
        }
    }
}