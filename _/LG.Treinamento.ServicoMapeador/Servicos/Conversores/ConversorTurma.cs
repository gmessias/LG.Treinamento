﻿using LG.Treinamento.InterfacesFabricas.ContratosDeServicos.Dados;
using LG.Treinamento.Negocio.Objetos;
using System.Collections.Generic;
using System.Linq;

namespace LG.Treinamento.ServicoMapeador.Servicos.Conversores
{
    public class ConversorTurma
    {
        private readonly ConversorEstagiario conversorEstagiario;

        public ConversorTurma(ConversorEstagiario conversorEstagiario)
        {
            this.conversorEstagiario = conversorEstagiario;
        }
        public DTOTurma Converta(Turma objeto)
        {
            return new DTOTurma
            {
                Id = objeto.Id,
                Nome = objeto.Nome,
                Estagiarios = conversorEstagiario.Converta(objeto.Estagiarios),
                Professor = objeto.Professor,
            };
        }
        public Turma Converta(DTOTurma dto)
        {
            return new Turma
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Estagiarios = conversorEstagiario.Converta(dto.Estagiarios),
                Professor = dto.Professor
            };
        }

        public IList<Turma> Converta(IList<DTOTurma> turmas)
        {
            return turmas.Select(turma => new Turma
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Estagiarios = conversorEstagiario.Converta(turma.Estagiarios),
                Professor = turma.Professor
            }).ToList();
        }
        public IList<DTOTurma> Converta(IList<Turma> turmas)
        {
            return turmas.Select(turma => new DTOTurma
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Estagiarios = conversorEstagiario.Converta(turma.Estagiarios),
                Professor = turma.Professor
            }).ToList();
        }

        public static Turma ConvertaTurmaSemEstagiarios(DTOTurma turma)
        {
            return new Turma
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Professor = turma.Professor,
                InformacoesComplementares = turma.InformacoesComplementares,
            };
        }

        public static DTOTurma ConvertaTurmaSemEstagiarios(Turma turma)
        {
            return new DTOTurma
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Professor = turma.Professor,
                InformacoesComplementares = turma.InformacoesComplementares,
            };
        }
    }
}
