using System.ComponentModel.DataAnnotations;

namespace MarkoWineStore.Models
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string StringRes1 { get; set; }
        public string StringRes2 { get; set; }
        public int Stock { get; set; }
        public int IntRes1 { get; set; }
        public int IntRes2 { get; set; }
        public decimal Price { get; set; }
    }
}