using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Transcription.Domain;
using Transcription.Domain.Entities;

namespace Transcription.Mvc.Controllers
{
    public class AudioFilesController : Controller
    {
        private readonly TranscriptionContext _context;

        public AudioFilesController(TranscriptionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не выбран.");

            var userId = GetUserId(); // Получите ID текущего пользователя
            var audioFile = new AudioFile
            {
                Name = file.FileName,
                Description = "Описание файла", //пока заглушка
                LoadDate = DateTime.Now,
                IsCompleted = false,
                UserId = userId
            };

            // Сохраниние файла на сервере (возможно нужно пока)
            var filePath = Path.Combine("wwwroot/uploads", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _context.AudioFiles.Add(audioFile);
            await _context.SaveChangesAsync();

            return Ok("Файл успешно загружен.");
        }

        private int GetUserId()
        {
            // Получаем текущего пользователя из контекста
            var claimsPrincipal = HttpContext.User;

            // Находим claim с идентификатором пользователя
            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            // Если идентификатор пользователя не найден, возвращаем значение по умолчанию или выбрасываем исключение
            throw new InvalidOperationException("Идентификатор пользователя не найден.");
        }
    }
}
