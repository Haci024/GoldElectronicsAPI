using Business.Services;
using DTO.DTOS.ContactUsDTO;
using DTO.DTOS.CvAndCareerDTO;
using DTO.DTOS.SubscriberDTO;
using DTO.DTOS.UsersDTO.RegisterDTO;
using Entity.Models;
using Humanizer;
using MimeKit;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Newtonsoft.Json;

namespace Business.Manager
{
    public class EmailManager : IEmailService
    {
        public void StartListening()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

           
            channel.QueueDeclare(queue: "careerQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailMessage = JsonConvert.DeserializeObject<AddCvDTO>(message);

              
                AutoMessageForCareer(emailMessage);
            };

            channel.BasicConsume(queue: "careerQueue", autoAck: true, consumer: consumer);
        }
        public void AutoMessageForCareer(AddCvDTO dto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("İşə qəbul üzrə müraciət", "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Odissey Electronics", dto.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Hörmətli müştərimiz , işə qəbul üzrə müraciətiniz bizə çatdı. Ən qısa zamanda Cv məlumatlarınız incələnəcək və " +
                $"sizə geri dönüş ediləcək. Əgər 14 gün ərzində geri dönüş edilməsə narahat olmayın. Məlumatlarınız CV bazamıza əlavə edilir və vakansiya" +
                $" tələblərini qarşılayırsınızsa, biz sizi məmnuniyyətlə aramızda görmək istəyərik." +
                $"Vakansiya elan edilən  zaman sizi interviyuya dəvət edəcik. Müraciətiniz üçün təşəkkür edirik. Sizə xoş gün arzulayırıq!";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "İşə qəbul üçün müraciət";

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "goyk wxvj kveh ksbm");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void AutoMessageForContactUs(NewContactUsDTO dto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(" Bizimlə əlaqə", "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Odissey Electronics", dto.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Hörmətli müştərimiz {dto.FullName} , mesajınız bizə çatdırıldı.Ən qisa zamanda sorğunuz cavablandırılacaq.";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = dto.Title;

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "goyk wxvj kveh ksbm");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void ConfirmCodeForNewUser(AppUser user)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("Hesab təsdiqləmə", "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Odissey Electronics", user.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Hörmətli müştərimiz {user.FullName} , Hesabınızı aktivləşdirmək üçün kodunuz:{user.ConfirmCode}";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Hesab təsdiqləmə";

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "goyk wxvj kveh ksbm");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void ForgetPasswordCodeMessage()
        {
            throw new NotImplementedException();
        }

        public void NewSubscriberMessage(NewSubscriberDTO dto)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubscriberMessage(RemoveSubscriberDTO dto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("Abunəliyin ləğvi", "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Odissey Electronics", dto.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Hörmətli müştərimiz , Abunəliyiniz uğurla dayandırıldı.";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Remove Subscribtion";

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "goyk wxvj kveh ksbm");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void ResetPasswordCodeMessage()
        {
            throw new NotImplementedException();
        }
    }
}
