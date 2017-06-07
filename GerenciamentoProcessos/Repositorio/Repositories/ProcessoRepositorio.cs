using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Repositorio.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Repositories
{
    public class ProcessoRepositorio : BaseRepositorio<Processo>, IProcessoRepositorio
    {
        private GerenciamentoProcessosContext _context;

        public ProcessoRepositorio(GerenciamentoProcessosContext context) : base(context)
        {
            _context = context;
        }

        public decimal SomaProcessosAtivos()
        {
            var result = _context.Processo.Where(p => p.Ativo == true)
                .Select(s => s.Valor).Sum();

            return result;
        }

        public decimal MediaPorClienteEstado(string cliente, string estado)
        {
            var result = (from p in _context.Processo
                     join c in _context.Cliente on p.ClienteId equals c.Id
                     where p.Estado.Equals(estado) && c.Nome.Equals(cliente)
                     select p.Valor).Average();

            return result;
        }

        public int NumeroProcessosAcima(decimal valor)
        {
            var result = _context.Processo.Where(p => p.Valor > valor)
                .Select(s => s.Valor).Count();

            return result;
        }

        public List<string> ListaProcessosPorData(int mes, int ano)
        {
            var result = _context.Processo.Where(p => p.DataCriacao.Month.Equals(mes) && p.DataCriacao.Year.Equals(ano))
                .Select(s => s.Numero).ToList();

            return result;
        }

        public List<string> ListaProcessosPorClienteEstado(string cliente)
        {
            var result = (from p in _context.Processo
                          join c in _context.Cliente on p.ClienteId equals c.Id
                          where p.Estado.Equals(c.Estado) && c.Nome.Equals(cliente)
                          select p.Numero).ToList();

            return result;
        }

        public List<string> ListaProcessosPorSigla(string sigla)
        {
            var result = (from p in _context.Processo
                          join c in _context.Cliente on p.ClienteId equals c.Id
                          where p.Numero.Contains(sigla)
                          select p.Numero).ToList();

            return result;
        }
    }
}