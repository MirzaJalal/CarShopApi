namespace CarShopApi.Models
{
    public class VehicleQueryParameters:QueryParameters
    {
        public  decimal? Min_Price { get; set; }
        public  decimal? Max_Price { get; set; }

        public string ModelSku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string SearchTerm { get; set; } = string.Empty;
         
    }
}
