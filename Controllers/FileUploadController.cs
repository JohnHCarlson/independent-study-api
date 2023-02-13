using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PindexBackend.Models;

namespace PindexBackend.Controllers {
    
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase {

        private readonly PindexContext _context;

        public FileUploadController(PindexContext context) {
            _context = context;
        }

        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetImageByItemId(int itemId) {

            var item = await _context.Items.Include(i => i.Image).SingleOrDefaultAsync(i => i.ItemId == itemId);
            if (item == null) {
                return NotFound();
            }

            var image = item.Image;
            if (image == null) {
                return NotFound();
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", image.FileName);
            var stream = new FileStream(filePath, FileMode.Open);

            return File(stream, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm]IFormFile image, [FromForm] int itemId) {

            var item = await _context.Items.FindAsync(itemId);
            
            if (item == null) {
                return BadRequest(String.Format("The item with the ID {0} does not exist.", itemId));
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);   
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                await image.CopyToAsync(fileStream);
            }

            var imageModel = new Image {
                FileName = fileName,
                UploadDate = DateTime.UtcNow,
                ItemId = itemId
            };

            _context.Images.Add(imageModel);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
