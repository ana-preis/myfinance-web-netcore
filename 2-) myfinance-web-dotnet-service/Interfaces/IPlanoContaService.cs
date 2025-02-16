using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
    public interface IPlanoContaService
    {
        void Register(PlanoConta Entity);
        void Delete(int Id);
        List<PlanoConta> ListItems();
        PlanoConta GetItem(int Id);
    }
}