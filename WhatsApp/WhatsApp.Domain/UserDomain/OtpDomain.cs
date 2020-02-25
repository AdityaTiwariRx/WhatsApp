using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Models.Main;
using System.Net;

namespace WhatsApp.Domain.UserModule
{
    public class OtpDomain : IOtpDomain
    {
        public OtpDomain(IUserUow uow) {
            this.Uow = uow;
        }

        public async Task<object> GetAsync(OtpUser parameters)
        {
            //throw new NotImplementedException();
            return await Uow.Repository<OtpUser>().AllAsync();
        }

        public async Task<object> GetBy(OtpUser parameters)
        {

            throw new NotImplementedException();
        }
        

        public HashSet<string> AddValidation(OtpUser entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(OtpUser entity)
        {
            //Generate Otp
            Random rnd = new Random();
            string randomNumber = (rnd.Next(100000, 999999)).ToString();
            entity.OtpCode = Int32.Parse(randomNumber);
            //Otp send via msg
           

            await Uow.RegisterNewAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> UpdateValidation(OtpUser entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(OtpUser entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(OtpUser parameters)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(OtpUser parameters)
        {
            throw new NotImplementedException();
        }

        public IUserUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface IOtpDomain : ICoreDomain<OtpUser, OtpUser> { }
}
