using System;
using WebAPI.Repository.Enums;

namespace WebAPI.Model.Request.CategoryDTOs
{
    public class CategoryEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status IsActive { get; set; }
    }
}
