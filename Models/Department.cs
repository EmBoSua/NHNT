using System;
using System.Collections;
using System.Collections.Generic;
using NHNT.Constants;

namespace NHNT.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public Decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public Decimal RoomAread { get; set; }
        public DepartmentStatus Status { get; set; }
        public string Discription { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longtide { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? GroupId { get; set; }
        public DepartmentGroup Group { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}