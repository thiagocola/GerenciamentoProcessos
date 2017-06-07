using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repositorio.Repositories
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected GerenciamentoProcessosContext Db;
        protected DbSet<TEntity> DbSet;
        protected DbContextTransaction transaction;

        public BaseRepositorio(GerenciamentoProcessosContext context)
        {
            Db = context;
            //DbSet = Db.Set<TEntity>();

            Db.Cliente = new List<Cliente>();
            Db.Cliente.Add(new Cliente() { Id = 1, Nome = "Empresa A", CNPJ = "00000000001", Estado = "Rio de Janeiro" });
            Db.Cliente.Add(new Cliente() { Id = 2, Nome = "Empresa B", CNPJ = "00000000002", Estado = "São Paulo" });

            Db.Processo = new List<Processo>();
            Db.Processo.Add(new Processo() { Id = 1, ClienteId = 1, Numero = "00001CIVELRJ", Estado = "Rio de Janeiro", DataCriacao = DateTime.Parse("2007-10-10"), Valor = 200000, Ativo = true });
            Db.Processo.Add(new Processo() { Id = 2, ClienteId = 1, Numero = "00002CIVELSP", Estado = "São Paulo", DataCriacao = DateTime.Parse("2007-10-20"), Valor = 100000, Ativo = true });
            Db.Processo.Add(new Processo() { Id = 3, ClienteId = 1, Numero = "00003TRABMG", Estado = "Minas Gerais", DataCriacao = DateTime.Parse("2007-10-30"), Valor = 10000, Ativo = false });
            Db.Processo.Add(new Processo() { Id = 4, ClienteId = 1, Numero = "00004CIVELRJ", Estado = "Rio de Janeiro", DataCriacao = DateTime.Parse("2007-11-10"), Valor = 20000, Ativo = false });
            Db.Processo.Add(new Processo() { Id = 5, ClienteId = 1, Numero = "00005CIVELSP", Estado = "São Paulo", DataCriacao = DateTime.Parse("2007-11-15"), Valor = 35000, Ativo = true });
            Db.Processo.Add(new Processo() { Id = 6, ClienteId = 2, Numero = "00006CIVELRJ", Estado = "Rio de Janeiro", DataCriacao = DateTime.Parse("2007-05-01"), Valor = 20000, Ativo = true });
            Db.Processo.Add(new Processo() { Id = 7, ClienteId = 2, Numero = "00007CIVELRJ", Estado = "Rio de Janeiro", DataCriacao = DateTime.Parse("2007-06-02"), Valor = 700000, Ativo = true });
            Db.Processo.Add(new Processo() { Id = 8, ClienteId = 2, Numero = "00008CIVELSP", Estado = "São Paulo", DataCriacao = DateTime.Parse("2007-07-03"), Valor = 500, Ativo = false });
            Db.Processo.Add(new Processo() { Id = 9, ClienteId = 2, Numero = "00009CIVELSP", Estado = "São Paulo", DataCriacao = DateTime.Parse("2007-08-04"), Valor = 32000, Ativo = true });
            Db.Processo.Add(new Processo() { Id = 10, ClienteId = 2, Numero = "00010TRABAM", Estado = "Amazonas", DataCriacao = DateTime.Parse("2007-09-05"), Valor = 1000, Ativo = false });
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            return objReturn;
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            //var entry = Db.Entry(obj);

            DbSet.Attach(obj);
            //entry.State = EntityState.Modified;

            return obj;
        }

        public virtual TEntity Atualizar(TEntity objOrigem, TEntity objDestino)
        {
            //var entry = Db.Entry(objOrigem);

            //DbSet.Attach(obj);
            //entry.State = EntityState.Modified;
            //entry.CurrentValues.SetValues(objDestino);
            return objDestino;
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}

        //public void BeginTransaction()
        //{
        //    transaction = Db.Database.BeginTransaction();
        //}

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        //private void LimparDbSet()
        //{
        //    DbSet.Local.ToList().ForEach(x =>
        //    {
        //        Db.Entry(x).State = EntityState.Detached;
        //    });
        //}

        public void Dispose()
        {
            //Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}