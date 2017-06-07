using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Context;
using System.Collections.Generic;

namespace Repositorio.Repositories.Tests
{
    [TestClass()]
    public class ProcessoRepositorioTests
    {
        private GerenciamentoProcessosContext context;
        private ProcessoRepositorio test;

        [TestInitialize]
        public void Initialize()
        {
            context = new GerenciamentoProcessosContext();
            test = new ProcessoRepositorio(context);
        }

        [TestMethod()]
        public void SomaProcessosAtivosTest()
        {
            Assert.AreEqual(test.SomaProcessosAtivos(), 1087000.00m);
        }

        [TestMethod()]
        public void MediaPorClienteEstadoTest()
        {
            Assert.AreEqual(test.MediaPorClienteEstado("Empresa A", "Rio de Janeiro"), 110000.00m);
        }

        [TestMethod()]
        public void NumeroProcessosAcimaTest()
        {
            Assert.AreEqual(test.NumeroProcessosAcima(100000m), 2);
        }

        [TestMethod()]
        public void ListaProcessosPorDataTest()
        {
            var compare = new List<string>() { "00010TRABAM" };
            CollectionAssert.AreEqual(test.ListaProcessosPorData(9, 2007), compare);
        }

        [TestMethod()]
        public void ListaProcessosPorClienteEstadoTest()
        {
            var compareA = new List<string>() { "00001CIVELRJ", "00004CIVELRJ" };
            CollectionAssert.AreEqual(test.ListaProcessosPorClienteEstado("Empresa A"), compareA);
            var compareB = new List<string>() { "00008CIVELSP", "00009CIVELSP" };
            CollectionAssert.AreEqual(test.ListaProcessosPorClienteEstado("Empresa B"), compareB);
        }

        [TestMethod()]
        public void ListaProcessosPorSiglaTest()
        {
            var compare = new List<string>() { "00003TRABMG", "00010TRABAM" };
            CollectionAssert.AreEqual(test.ListaProcessosPorSigla("TRAB"), compare);
        }
    }
}