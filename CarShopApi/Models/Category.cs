namespace CarShopApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
