using System;

namespace Dominio.Entities
{
    public class Processo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}