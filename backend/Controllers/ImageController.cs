using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using System.IO;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly Context _context;

        public ImageController(Context context)
        {
            _context = context;
        }

        // GET: api/Image
        //Get image by item id and image id
        [HttpGet("{itemId}/{imageId}")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages(int itemId, int imageId)
        {

            var imagesCall = from items in _context.Items
                             join images in _context.Images on items.Id equals images.ItemId
                             where items.Id == itemId && images.Id == imageId
                             select images.ImageURL;

            Byte[] b = System.IO.File.ReadAllBytes(imagesCall.FirstOrDefault());
            if (b == null)
            {
                return NotFound();
            }

            return File(b, "image/jpeg");


        }
        [HttpGet("itemid/{itemId}")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages(int itemId)
        {

            var imagesCall = from items in _context.Items
                             join images in _context.Images on items.Id equals images.ItemId
                             where items.Id == itemId
                             select images.ImageURL;
            var image = imagesCall.FirstOrDefault();
            Byte[] b = System.IO.File.ReadAllBytes(image);
            if (b == null)
            {
                return NotFound();
            }

            return File(b, "image/jpeg");
        }


        // GET: api/Image/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Image>> GetImage(int Id)
        {
            var image = await _context.Images.FindAsync(Id);

            Byte[] b = System.IO.File.ReadAllBytes(image.ImageURL);
            if (b == null)
            {
                return NotFound();
            }

            return File(b, "image/jpeg");
        }
        [HttpGet("collectionId/{colId}")]
        public async Task<ActionResult<List<Image>>> GetImagesFromCollection(int colId)
        {
            List<Item> itemDataFromDB = await _context.Items.Where(i => i.UserCollectionsId == colId).ToListAsync();
            List<Image> imageDataFromDB = new List<Image>();

            foreach (var item in itemDataFromDB)
            {

                Image im = new Image();

                im = await _context.Images.Where(i => i.ItemId == item.Id).FirstOrDefaultAsync();
                if (im == null)
                {
                    Image image = new Image();
                    image.ItemId = item.Id;
                    image.ImageURL = ("https://www.gardeningknowhow.com/wp-content/uploads/2010/02/iStock-524907632.jpg");
                    imageDataFromDB.Add(image);
                }
                else
                {
                    im.ItemId = item.Id;
                    im.ImageURL = "http://localhost:5000/api/Image/" + item.Id + "/" + im.Id;
                    imageDataFromDB.Add(im);
                }

            }

            return imageDataFromDB;
        }


        [HttpGet("Item/{itemId}")]
        public async Task<ActionResult<List<string>>> GetImageFromItemId(int itemId)
        {
            //var image = await _context.Images.FindAsync(Id);
            List<Image> imageDataFromDB = await _context.Images.Where(i => i.ItemId == itemId).ToListAsync();

            //Byte[] b = System.IO.File.ReadAllBytes(image.ImageURL);
            if (imageDataFromDB == null)
            {
                return NotFound();
            }
            List<string> imageUrls = new List<string>();
            //http://localhost:5000/api/Image/itemid/1

            foreach (var image in imageDataFromDB)
            {
                imageUrls.Add("http://localhost:5000/api/Image/" + image.ItemId + "/" + image.Id);
            }



            return imageUrls;
        }


        // POST: api/Image
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {



            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.Id }, image);
        }
        [HttpPost("{itemId}/images")]
        public FileContentResult UploadCustomerImage(int itemId, [FromBody] ImageData model)
        {
            //Depending on if you want the byte array or a memory stream, you can use the below. 
            var imageDataByteArray = Convert.FromBase64String(model.Image);

            //When creating a stream, you need to reset the position, without it you will see that you always write files with a 0 byte length. 
            var imageDataStream = new MemoryStream(imageDataByteArray);
            imageDataStream.Position = 0;



            Image image = new Image();
            var newname = _context.Images.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            System.IO.File.WriteAllBytes(@"Images\" + newname + ".jpg", imageDataByteArray);
            image.ItemId = itemId;
            image.ImageURL = @"Images\" + newname + ".jpg";
            _context.Images.Add(image);
            _context.SaveChangesAsync();
            return File(imageDataByteArray, "image/png");
        }
        // DELETE: api/Image/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Image>> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
