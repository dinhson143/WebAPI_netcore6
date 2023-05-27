using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Enums;

namespace WebAPI.Repository.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsShowHome { get; set; }
        public Status Status { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
