using DTO.DTOS.SubscriberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IEmailService
    {
        Task NewSubscriberMessage(NewSubscriberDTO dto);
        Task ForgetPasswordCodeMessage(NewSubscriberDTO dto);
        Task ResetPasswordCodeMessage(NewSubscriberDTO dto);
        Task RemoveSubscriberMessage(NewSubscriberDTO dto);
    }
}
