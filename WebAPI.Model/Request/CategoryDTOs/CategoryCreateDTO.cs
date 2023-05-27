namespace WebAPI.Model.Request.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
