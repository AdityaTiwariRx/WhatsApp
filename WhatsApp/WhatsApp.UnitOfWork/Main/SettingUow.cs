using RxWeb.Core.Data;
using WhatsApp.BoundedContext.Main;

namespace WhatsApp.UnitOfWork.Main
{
    public class SettingUow : BaseUow, ISettingUow
    {
        public SettingUow(ISettingContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface ISettingUow : ICoreUnitOfWork { }
}


