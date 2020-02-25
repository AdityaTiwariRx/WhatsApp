using RxWeb.Core.Data;
using WhatsApp.BoundedContext.Main;

namespace WhatsApp.UnitOfWork.Main
{
    public class StatusUow : BaseUow, IStatusUow
    {
        public StatusUow(IStatusContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface IStatusUow : ICoreUnitOfWork { }
}


