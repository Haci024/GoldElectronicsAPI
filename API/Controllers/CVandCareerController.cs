using Business.Services;
using DTO.DTOS.CvAndCareerDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVandCareerController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IGoogleCloudStorageService _googleCloudStorageService;
        private readonly INotficationService _notfications;
        private readonly ICvAndCareerService _cvAndCareerService;

        public CVandCareerController(IEmailService emailService, IGoogleCloudStorageService googleCloudStorageService,INotficationService notfications ,ICvAndCareerService cvAndCareerService)
        {
            _emailService = emailService;
            _notfications = notfications;
            _googleCloudStorageService = googleCloudStorageService;
            _cvAndCareerService = cvAndCareerService;
        }
        [HttpGet("UnViewedCvList")]
        public async Task<IActionResult> UnViewedCvList()
        {

            return Ok(await _cvAndCareerService.UnViewedCvList());
        }
        [HttpGet("ViewedCvList")]
        public async Task<IActionResult> ViewedCvList()
        {

            return Ok(await _cvAndCareerService.ViewedCvList());
        }
        [HttpPost("SendCV")]
        public async Task<IActionResult> SendCV(AddCvDTO dto)
        {
            CvAndCareer entity = new();
            entity.SendingDate = dto.SendingDate;
            entity.IsView = dto.IsView;
            entity.WorkType = dto.WorkType;
            entity.Email = dto.Email;
            entity.SavedFileUrl = GenerateFileNameToSave(dto.CvFile.FileName);
            entity.FileUrl = await _googleCloudStorageService.UploadFile(dto.CvFile, entity.SavedFileUrl);
            _emailService.AutoMessageForCareer(dto);
            await _notfications.AddNotficationByAction(4,entity.Id);
           await  _cvAndCareerService.Create(entity);
            return Ok(dto);
        }
        [HttpPut]
        public async Task<IActionResult> ViewCv(int Id)
        {
            CvAndCareer entity = _cvAndCareerService.GetById(Id);
            entity.IsView = true;
            await _cvAndCareerService.Update(entity);
            return Ok("Cv oxundu.");
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }
    }
}



