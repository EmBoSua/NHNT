using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Http;
using NHNT.Models;
using NHNT.Repositories;
using NHNT.Utils;

namespace NHNT.Services.Implement
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public void saveMultiple(ICollection<IFormFile> images, Department department)
        {

            if (images != null & images.Count > 0)
            {
                string _uploadFolderPath = "Static/Upload/Images";
                Guid uid = Guid.NewGuid();
                string uidString = uid.ToString();

                if (!Directory.Exists(_uploadFolderPath))
                {
                    Directory.CreateDirectory(_uploadFolderPath);
                }

                DateTime currentTime = DateTimeUtils.GetCurrentTime();

                foreach (IFormFile item in images)
                {

                    string fileName = $"{uid}_{item.FileName}";
                    string filePath = Path.Combine(_uploadFolderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }

                    var image = new Image
                    {
                        Path = fileName,
                        CreatedAt = currentTime,
                        Department = department
                    };
                    _imageRepository.Add(image);
                }
            }
            throw new System.NotImplementedException();
        }
    }
}
