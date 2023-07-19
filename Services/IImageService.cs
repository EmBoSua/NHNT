
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NHNT.Models;

namespace NHNT.Services
{
    public interface IImageService
    {
        void saveMultiple(ICollection<IFormFile> images, Department department);
    }
}