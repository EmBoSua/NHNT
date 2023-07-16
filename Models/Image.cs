using System;

namespace NHNT.Models
{
    public class Image
    {
        public int Id {get; set;}
        public string Path {get; set;}
        public DateTime CreateAt {get; set;}
        public int? DepartmentId {get; set;}
        public Department Department {get; set;}
    }
}