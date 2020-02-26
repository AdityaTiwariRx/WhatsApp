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

        public async Task<object> GetAsync(BlockedUser entity)
        {
            return await Uow.Repository<BlockedUser>().AllAsync();
            throw new NotImplementedException();
        }

        public Task<object> GetBy(BlockedUser entity)
        {
            throw new NotImplementedException();
        }
        

        public HashSet<string> AddValidation(BlockedUser entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(BlockedUser entity)
        {
            if(entity.IsBlocked==true)
            {
                entity.UsercontactId = entity.BlockedUserId;
            }
            await Uow.RegisterNewAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> UpdateValidation(BlockedUser entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(BlockedUser entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(BlockedUser entity)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(BlockedUser entity)
        {
            throw new NotImplementedException();
        }

        public ISettingUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface IBlockDomain : ICoreDomain<BlockedUser,BlockedUser> { }
}
