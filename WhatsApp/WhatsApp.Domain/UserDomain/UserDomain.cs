using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Models.Main;
using RxWeb.Core.Security.Cryptography;

namespace WhatsApp.Domain.UserModule
{
    public class UserDomain : IUserDomain
    {
        private IPasswordHash PasswordHash { get; set; }
        public UserDomain(IUserUow uow) {
            this.Uow = uow;
        }

        public async Task<object> GetAsync(User parameters)
        {
            return await Uow.Repository<User>().AllAsync();

        }

        public Task<object> GetBy(User parameters)
        {
            throw new NotImplementedException();
        }

        

        public HashSet<string> AddValidation(User entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(User entity)
        {
            /* byte[] arr = System.Text.Encoding.ASCII.GetBytes("h");
             entity.Password = arr;
             entity.Salt = arr;*/
            //entity.Password = System.Text.Encoding.ASCII.GetBytes(entity.pwd);
            //entity.Salt = System.Text.Encoding.ASCII.GetBytes(entity.slt);


            await Uow.RegisterNewAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> UpdateValidation(User entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(User entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(User parameters)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(User parameters)
        {
            throw new NotImplementedException();
        }

        public IUserUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface IUserDomain : ICoreDomain<User,User> { }
}
