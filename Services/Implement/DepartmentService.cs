using NHNT.Constants.Statuses;
using NHNT.Dtos;
using NHNT.Exceptions;
using NHNT.Models;
using NHNT.Repositories;
using NHNT.Utils;
using System;

namespace NHNT.Services.Implement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IImageService _imageService;

        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IImageService imageService
            )
        {
            this._departmentRepository = departmentRepository;
            _imageService = imageService;
        }


        public DepartmentDto[] List(int page, int limit)
        {
            var departments = _departmentRepository.List(page, limit);
            DepartmentDto[] result = { };

            return result;
        }

        public Department GetById(int id)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            return department;
        }

        public void register(DepartmentRegisDto departmentDto)
        {

            DateTime currentTime = DateTimeUtils.GetCurrentTime(); ;

            var department = new Department
            {
                Address = departmentDto.Address,
                Price = departmentDto.Price,
                PhoneNumber = departmentDto.PhoneNumber,
                Acreage = departmentDto.Acreage,
                Status = departmentDto.Status,
                Description = departmentDto.Description,
                IsAvailable = departmentDto.IsAvailable,
                CreatedAt = currentTime,
                UpdatedAt = currentTime,
                UserId = departmentDto.UserId,
                GroupId = departmentDto.GroupId,
            };
            _departmentRepository.Add(department);
            _imageService.saveMultiple(departmentDto.Images, department.Id);

            throw new System.NotImplementedException();
        }
    }
}