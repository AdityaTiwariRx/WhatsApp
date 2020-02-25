using RxWeb.Core.Data;
using WhatsApp.BoundedContext.Main;

namespace WhatsApp.UnitOfWork.Main
{
    public class UserUow : BaseUow, IUserUow
    {
        public UserUow(IUserContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface IUserUow : ICoreUnitOfWork { }
}


