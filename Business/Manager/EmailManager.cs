using Business.Services;
using DTO.DTOS.SubscriberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class EmailManager : IEmailService
    {
    
        public Task ForgetPasswordCodeMessage(NewSubscriberDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task NewSubscriberMessage(NewSubscriberDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSubscriberMessage(NewSubscriberDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordCodeMessage(NewSubscriberDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
