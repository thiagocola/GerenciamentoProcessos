using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Repositorio.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Repositories
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
        private GerenciamentoProcessosContext _context;

        public ClienteRepositorio(GerenciamentoProcessosContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var result = (from p in _context.Processo
                     join c in _context.Cliente on p.ClienteId equals c.Id
                     group p by c into g
                     select new Cliente { Id = g.Key.Id, CNPJ = g.Key.CNPJ, Estado = g.Key.Estado, Nome = g.Key.Nome, Processos = g.ToList() });

            return result;
        }
    }
}