using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RabbitMQController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
             HostName= "localhost",
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Kanal2",false,false,false,arguments:null);
            var messageContent = "Bu mesaj test üçün göndərilir!";
            var byteMessageContent=Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange:"",routingKey:"Kanal2",basicProperties:null,body:byteMessageContent);
            
            return Ok("Mesaj göndərildi!");
        }
    }
}
