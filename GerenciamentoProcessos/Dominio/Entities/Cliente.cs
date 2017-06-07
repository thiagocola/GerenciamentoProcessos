using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Processo> Processos { get; set; }
    }
}