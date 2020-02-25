using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Models.Main;
using WhatsApp.Models.ViewModels;

namespace WhatsApp.Domain.SettingModule
{
    public class BlockDomain : IBlockDomain
    {
        public BlockDomain(ISettingUow uow) {
            this.Uow = uow;
        }

        

        public async Task<object> GetAsync(BlockedNumber entity)
        {
            return await Uow.Repository<BlockedNumber>().AllAsync();
            throw new NotImplementedException();
        }

        public Task<object> GetBy( BlockedNumber entity)
        {
            throw new NotImplementedException();
        }
        

        public HashSet<string> AddValidation(BlockedNumber entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(BlockedNumber entity)
        {
            if(entity.IsBlocked == true)
            {
                entity.UsercontactId = entity.BlockedUserId;
            }
            await Uow.RegisterNewAsync(entity);
            await Uow.CommitAsync(); 
        }

        public HashSet<string> UpdateValidation(BlockedNumber entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(BlockedNumber entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(BlockedNumber entity)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(BlockedNumber entity)
        {
            throw new NotImplementedException();
        }

        public ISettingUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface IBlockDomain : ICoreDomain<BlockedNumber,BlockedNumber> { }
}
