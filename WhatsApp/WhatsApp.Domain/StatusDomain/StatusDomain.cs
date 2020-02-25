using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Models.Main;

namespace WhatsApp.Domain.StatusModule
{
    public class StatusDomain : IStatusDomain
    {
        public StatusDomain(IStatusUow uow) {
            this.Uow = uow;
        }

        public Task<object> GetAsync( parameters)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetBy( parameters)
        {
            throw new NotImplementedException();
        }
        

        public HashSet<string> AddValidation(Status entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(Status entity)
        {
            await Uow.RegisterNewAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> UpdateValidation(Status entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(Status entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(Status parameters)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(Status parameters)
        {
            throw new NotImplementedException();
        }

        public IStatusUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface IStatusDomain : ICoreDomain<Status,> { }
}
