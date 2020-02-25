using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Models.Main;


namespace WhatsApp.Domain.UserModule
{
    public class CheckOtpDomain : ICheckOtpDomain
    {
        OtpUser otp;
        int myId;
        public CheckOtpDomain(IUserUow uow) {
            this.Uow = uow;
            otp = new OtpUser();
            myId = 0;
            
        }

        public async Task<object> GetAsync(OtpUser parameters)
        {
            return await Uow.Repository<OtpUser>().AllAsync();
            //throw new NotImplementedException();
        }

        public async Task<object> GetBy(OtpUser parameters)
        {
            
            return await Uow.Repository<OtpUser>().AllAsync();
            //throw new NotImplementedException();
        }
        

        public HashSet<string> AddValidation(OtpUser entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(OtpUser entity)
        {
            
            if(entity.OtpCode==otp.OtpCode && entity.UserId==otp.UserId )
            {
                Console.WriteLine("matched");
                await Uow.CommitAsync();
            }
            else
            {
                Console.WriteLine("not matched");
            }
            /*await Uow.RegisterNewAsync(entity);*/
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

    public interface ICheckOtpDomain : ICoreDomain<OtpUser,OtpUser> { }
}
