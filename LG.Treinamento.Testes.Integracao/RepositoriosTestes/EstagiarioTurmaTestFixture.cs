﻿using FluentAssertions;
using LG.Treinamento.Negocio.Objetos;
using LG.Treinamento.ServicoMapeador.Mapeadores.Mapeamentos;
using NUnit.Framework;
using System.Collections.Generic;

namespace LG.Treinamento.Testes.Integracao.RepositoriosTestes
{
    public class EstagiarioTurmaTestFixture : DataBaseEmMemoria
    {
        public EstagiarioTurmaTestFixture() : base(typeof(EstagiarioMap).Assembly)
        {
        }

        [Test]
        public void PodeSalvarEObterEstagiarioETurma()
        {
            using (var transacao = session.BeginTransaction())
            {
                var turma = new Turma
                {
               
                    Nome = "Cleber",
                    InformacoesComplementares = new Dictionary<string, string>
                    {
                        {"DiaInicio", "07/03"}
                    }
                };
                var estagiario = new Estagiario
                {
                    
                    Nome = "Marcos",
                    Turma = turma,
                    Endereco = new Endereco
                    {
                        Lote = 1,
                        Quadra = 1,
                        Numero = "1",
                        Rua = "1",
                    }
                };

                turma.Estagiarios = new List<Estagiario> { estagiario };

                session.Save(turma);
                session.Save(estagiario);

                var estagiarioSalvo = session.Get<Estagiario>(estagiario.Id);
                estagiario.Should().Be(estagiarioSalvo);

                var turmaSalva = session.Get<Turma>(turma.Id);
                turma.Should().Be(turmaSalva);

                transacao.Commit();
            }
        }
    }
}
