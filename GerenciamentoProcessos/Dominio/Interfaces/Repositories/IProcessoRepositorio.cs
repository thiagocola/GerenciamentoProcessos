using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositories
{
    public interface IProcessoRepositorio : IBaseRepositorio<Processo>
    {
        decimal SomaProcessosAtivos();
        decimal MediaPorClienteEstado(string cliente, string estado);
        int NumeroProcessosAcima(decimal valor);
        List<string> ListaProcessosPorData(int mes, int ano);
        List<string> ListaProcessosPorClienteEstado(string cliente);
        List<string> ListaProcessosPorSigla(string sigla);
    }
}