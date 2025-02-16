using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;
using myfinance_web_dotnet_infra;

namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {

        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int Id)
        {
            var Transacao = new Transacao() { Id = Id };
            _dbContext.Transacao.Attach(Transacao);
            _dbContext.Transacao.Remove(Transacao);
            _dbContext.SaveChanges();
        }

        public Transacao GetItem(int Id)
        {
            return _dbContext.Transacao.Where(x => x.Id == Id).First();
        }

        public List<Transacao> ListItems()
        {
            var dbSet = _dbContext.Transacao;
            return dbSet.ToList();
        }

        public void Register(Transacao Entity)
        {
            var dbSet = _dbContext.Transacao;
            if (Entity.Id == null)
            {
                dbSet.Add(Entity);
            }
            else
            {
                dbSet.Attach(Entity);
                _dbContext.Entry(Entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
        
    }
}