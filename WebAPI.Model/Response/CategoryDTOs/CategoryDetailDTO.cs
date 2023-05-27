using System;
using System.Collections.Generic;

namespace WebAPI.Model.Response.CategoryDTOs
{
    public class CategoryDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
    }
}
