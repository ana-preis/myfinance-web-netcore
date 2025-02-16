using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
    public interface ITransacaoService
    {
        void Register(Transacao Entity);
        void Delete(int Id);
        List<Transacao> ListItems();
        Transacao GetItem(int Id);
    }
}