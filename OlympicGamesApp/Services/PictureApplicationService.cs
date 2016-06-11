using OlympicGamesApp.DataAccess.Models;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.Services
{
    public class PictureApplicationService
    {
        private IRepository<Picture> _pictureRepository;
        private IRepository<Customer> _customerRepository;

        public PictureApplicationService(IRepository<Picture> pictureRepository, IRepository<Customer> customerRepository)
        {
            _pictureRepository = pictureRepository;
            _customerRepository = customerRepository;
        }

        public Picture CreatePicture(byte[] imageData, string imageContentType, string imageFilename, byte[] thumbData, string thumbFileName, string thumbContentType)
        {
            var picture = new Picture()
            {
                Image = imageData,
                ImageContentType = imageContentType,
                ImageFileName = imageFilename,
                Thumbnail = thumbData,
                ThumbnailContentType = thumbContentType,
                ThumbnailFileName = thumbFileName
            };

            _pictureRepository.Add(picture);

            return picture;
        }

        public Picture UpdatePicture(int id, byte[] imageData, string imageContentType, string imageFilename, byte[] thumbData, string thumbFileName, string thumbContentType)
        {
            var picture = _pictureRepository.Get(id);

            if (picture == null)
            {
                throw new InvalidOperationException("No picture with the provided id was found!");
            }

            picture.Image = imageData;
            picture.ImageContentType = imageContentType;
            picture.ImageFileName = imageFilename;
            picture.Thumbnail = thumbData;
            picture.ThumbnailContentType = thumbContentType;
            picture.ThumbnailFileName = thumbFileName;


            _pictureRepository.Update(picture);
            return picture;
        }

        public Picture RemovePicture(int id)
        {
            var picture = _pictureRepository.Get(id);

            if (picture == null)
            {
                throw new InvalidOperationException("No picture with the provided id was found!");
            }

            var thisCustomer = _customerRepository.AsQueryable().FirstOrDefault(c => c.PictureId == id);

            if (thisCustomer.GenderId == 1)
            {
                thisCustomer.PictureId = 1;
            }
            else
            {
                thisCustomer.PictureId = 2;
            }
            _customerRepository.Update(thisCustomer);
            _pictureRepository.Delete(picture);

            return picture;
        }

        public void DeletePicture(int id)
        {
            var picture = _pictureRepository.Get(id);

            if (picture == null)
            {
                throw new InvalidOperationException("No picture with the provided id was found!");
            }

            _pictureRepository.Delete(picture);
        }
    }
}
