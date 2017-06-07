using Dominio.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repositorio.Context
{
    public class GerenciamentoProcessosContext// : DbContext
    {
        public List<Cliente> Cliente { get; set; }
        public List<Processo> Processo { get; set; }

        //public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Processo> Processo { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}