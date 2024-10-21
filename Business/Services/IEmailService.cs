using DTO.DTOS.ContactUsDTO;
using DTO.DTOS.CvAndCareerDTO;
using DTO.DTOS.SubscriberDTO;
using DTO.DTOS.UsersDTO.RegisterDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IEmailService
    {
        void NewSubscriberMessage(NewSubscriberDTO dto);
        void ForgetPasswordCodeMessage();
        void ResetPasswordCodeMessage();
        void RemoveSubscriberMessage(RemoveSubscriberDTO dto);
        void ConfirmCodeForNewUser(AppUser user);
        void AutoMessageForContactUs(NewContactUsDTO dto);
        void AutoMessageForCareer(AddCvDTO dto);
    }
}
