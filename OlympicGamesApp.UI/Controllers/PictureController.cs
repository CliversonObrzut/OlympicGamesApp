using OlympicGamesApp.DataAccess.Models;
using OlympicGamesApp.Services;
using OlympicGamesApp.UI.ViewModels.Customer;
using OlympicGamesApp.UI.ViewModels.Picture;
using SharpRepository.EfRepository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.Controllers
{
    public class PictureController : Controller
    {
        protected OlympicDbContext _context;
        protected EfRepository<Picture> _pictureRepository;
        protected EfRepository<Customer> _customerRepository;
        protected PictureApplicationService _pictureService;
        protected CustomerApplicationService _customerService;

        public PictureController()
        {
            _context = new OlympicDbContext();
            _pictureRepository = new EfRepository<Picture>(_context);
            _customerRepository = new EfRepository<Customer>(_context);
            _pictureService = new PictureApplicationService(_pictureRepository, _customerRepository);
            _customerService = new CustomerApplicationService(_customerRepository, _pictureRepository);
        }

        // GET: Picture
        public ActionResult Index()
        {
            var model = _context.Pictures.ToList()
                 .Select(c => new PictureIndexViewModel()
                 {
                     Id = c.Id,
                     ImageFileName = c.ImageFileName,
                     ImageContentType = c.ImageContentType,
                     ThumStringData = c.Thumbnail == null ?
                     "Not available" :
                     String.Format("data:{0};base64,{1}", c.ThumbnailContentType, Convert.ToBase64String(c.Thumbnail))

                 });

            return View(model);
        }

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                var model = new PictureCreateViewModel();
                return View(model);
            }
            else
            {
                var customer = _context.Customers.Find(id);

                var model = new PictureCreateViewModel()
                {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    PictureId = customer.PictureId
                };
                return View(model);
            }            
        }

        [HttpPost]
        public ActionResult Create(PictureCreateViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BinaryReader binaryReader = new BinaryReader(image.InputStream);
                    byte[] imageData = binaryReader.ReadBytes(image.ContentLength);

                    Image img = Image.FromStream(image.InputStream, true, true);
                    Image thumbnail = img.GetThumbnailImage(25, 25, () => false, IntPtr.Zero);
                    var stream = new MemoryStream();
                    thumbnail.Save(stream, ImageFormat.Jpeg);
                    BinaryReader binaryReaderThumbnail = new BinaryReader(stream);
                    byte[] thumbImgData = stream.ToArray();


                    var picture = _pictureService.CreatePicture(
                        imageData: imageData,
                        imageContentType: image.ContentType,
                        imageFilename: image.FileName,

                        thumbData: thumbImgData,
                        thumbContentType: "image/jpeg",
                        thumbFileName: String.Format("Thum_{0}", image.FileName)
                        );

                    if(model.CustomerId == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _customerService.UpdateCustomerPicture((int)model.CustomerId, picture.Id);
                        return RedirectToAction("Details", "Customer", new { id = model.CustomerId });
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var picture = _context.Pictures.Find(id);

            if (picture == null)
            {
                return HttpNotFound();
            }

            var model = new PictureEditViewModel()
            {
                PictureId = picture.Id,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PictureEditViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BinaryReader binaryReader = new BinaryReader(image.InputStream);
                    byte[] imageData = binaryReader.ReadBytes(image.ContentLength);

                    Image img = Image.FromStream(image.InputStream, true, true);
                    Image thumbnail = img.GetThumbnailImage(25, 25, () => false, IntPtr.Zero);
                    var stream = new MemoryStream();
                    thumbnail.Save(stream, ImageFormat.Jpeg);
                    BinaryReader binaryReaderThumbnail = new BinaryReader(stream);
                    byte[] thumbImgData = stream.ToArray();


                    var picture = _pictureService.UpdatePicture(
                        model.PictureId,
                        imageData: imageData,
                        imageContentType: image.ContentType,
                        imageFilename: image.FileName,

                        thumbData: thumbImgData,
                        thumbContentType: "image/jpeg",
                        thumbFileName: String.Format("Thum_{0}", image.FileName)
                        );

                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Remove(PictureCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pictureService.RemovePicture((int)model.PictureId);
                    return RedirectToAction("Details", "Customer", new { id = model.CustomerId });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }
            return View(model);
        }

        public ActionResult Picture(int? id)
        {
            var picture = _context.Pictures.Find(id);
            return File(picture.Image, picture.ImageContentType, picture.ImageFileName);
        }
    }
}