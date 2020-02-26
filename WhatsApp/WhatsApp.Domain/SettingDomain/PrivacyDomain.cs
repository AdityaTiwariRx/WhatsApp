using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Models.Main;

namespace WhatsApp.Domain.SettingModule
{
    public class PrivacyDomain : IPrivacyDomain
    {
        public PrivacyDomain(ISettingUow uow) {
            this.Uow = uow;
        }

        public async Task<object> GetAsync( Privacy entity)
        {
            return await Uow.Repository<Privacy>().AllAsync();
            throw new NotImplementedException();
        }

        public Task<object> GetBy(Privacy entity)
        {
            throw new NotImplementedException();
        }
        

        public HashSet<string> AddValidation(Privacy entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(Privacy entity)
        {
            await Uow.RegisterNewAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> UpdateValidation(Privacy entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(Privacy entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(Privacy entity)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(Privacy entity)
        {
            throw new NotImplementedException();
        }

        public ISettingUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface IPrivacyDomain : ICoreDomain<Privacy,Privacy> { }
}
