using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;
using myfinance_web_dotnet_infra;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {

        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int Id)
        {
            var PlanoConta = new PlanoConta() { Id = Id };
            _dbContext.PlanoConta.Attach(PlanoConta);
            _dbContext.PlanoConta.Remove(PlanoConta);
            _dbContext.SaveChanges();
        }

        public PlanoConta GetItem(int Id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == Id).First();
        }

        public List<PlanoConta> ListItems()
        {
            var dbSet = _dbContext.PlanoConta;
            return dbSet.ToList();
        }

        public void Register(PlanoConta Entity)
        {
            var dbSet = _dbContext.PlanoConta;
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