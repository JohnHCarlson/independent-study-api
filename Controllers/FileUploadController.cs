using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PindexBackend.Models;

namespace PindexBackend.Controllers {
    
    [Route("api/item/image")]
    [ApiController]
    public class FileUploadController : ControllerBase {

        private readonly PindexContext _context;

        public FileUploadController(PindexContext context) {
            _context = context;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UploadFile([FromForm]IFormFile imageFile, int id) {

            var item = await _context.Items.FindAsync(id);

            if (imageFile != null && imageFile.Length > 0) {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    await imageFile.CopyToAsync(stream);
                }
                item.ImageUrl = filePath;
            }

            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
